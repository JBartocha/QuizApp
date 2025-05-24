using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QuizApp
{
    internal class GameDatabaseOperator
    {
        private readonly string _connectionString = "";

        public GameDatabaseOperator()
        {
            string DBfilename = Environment.CurrentDirectory;
            for (int i = 0; i < 3; i++)
            {
                DBfilename = Directory.GetParent(DBfilename)?.ToString() ??
                    throw new InvalidOperationException("Parent directory is null.");
            }
            DBfilename += "\\MainDatabase.mdf";

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = @DBfilename,
                IntegratedSecurity = true
            };
            _connectionString = builder.ConnectionString;
        }

        public Question GetQuestion(int questionId)
        {
            Question question = new Question();
            question.Answers = new List<string>();
            try
            {
                int? pictureId = null; // Initialize pictureId to null to avoid CS0165

                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                string query = "SELECT Title, Question, Difficulty, PictureID, Link FROM Questions WHERE QuestionID = @QuestionID";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@QuestionID", questionId);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Title = reader.GetString(reader.GetOrdinal("Title"));
                    string Question = reader.GetString(reader.GetOrdinal("Question"));
                    int Difficulty = reader.GetInt32(reader.GetOrdinal("Difficulty"));
                    pictureId = reader.IsDBNull(reader.GetOrdinal("PictureID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("PictureID"));
                    string Link = reader.GetString(reader.GetOrdinal("Link"));
                    question.QuestionID = questionId;
                    question.QuestionTitle = Title;
                    question.QuestionText = Question;
                    question.QuestionDifficulty = Difficulty;
                    question.QuestionLink = Link;
                }

                if (pictureId.HasValue)
                {
                    string[] pictureData = GetPictureTable(pictureId.Value);
                    question.QuestionPictureName = pictureData[0];
                    question.QuestionPictureDescription = pictureData[1];
                }
                else
                {
                    question.QuestionPictureName = null;
                    question.QuestionPictureDescription = null;
                }
                List<Answer> answers = new List<Answer>();
                answers = GetAnswersTable(questionId);

                for (int i = 0; i < answers.Count; i++)
                {
                    
                    question.Answers.Add(answers[i].AnswerText);
                    if (answers[i].IsCorrect)
                    {
                        question.CorrentAnswer = i;
                    }
                }

                return question;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in method CheckIfCathegoryExists: {ex.Message}");
                throw new Exception("Error checking cathegory existence", ex);
            }
        }

        public void AnswerSelection(int questionID, string[] answers, string pickedAnswer)
        {

            // 1. ZJISTENI ZDA JE ODPOVED SPRAVNA
            bool isCorrect = false;
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT Correct FROM Questions " +
                "JOIN Answers ON Questions.QuestionID = Answers.AnswerGroupID " +
                "WHERE Answers.Answer = @PickedAnswer";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PickedAnswer", pickedAnswer);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isCorrect = reader.GetBoolean(reader.GetOrdinal("Correct"));
                    }
                    //Debug.WriteLine($"Answer selected: {pickedAnswer}, Correct: {isCorrect}");
                }
            }
            
            // 2. ZAPISANI STATISTIK v tabulce Questions
            string updateQuery;
            if (isCorrect)
            {
                updateQuery = "UPDATE Questions SET TimesAnswered = TimesAnswered + 1, " +
                        "TimesAnsweredCorrectly = TimesAnsweredCorrectly + 1 " +
                        "WHERE QuestionID = @questionID";
            }
            else
            {
                updateQuery = "UPDATE Questions SET TimesAnswered = TimesAnswered + 1 " +
                        "WHERE QuestionID = @questionID";
            }
            using (var updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@questionID", questionID);
                updateCommand.ExecuteNonQuery();
            }

            // 3.1 Zjistit unique ID pro vybranou odpověď a pro ostatní odpovědi
            int? pickedAnswerID = null;
            int[] answersID = new int[answers.Length];

            // 3.1.1 Zjistit ID pro pickedAnswer (vybranou odpoved)
            string getPickedAnswerIDQuery = "SELECT Answers.AnswersID FROM Questions " +
                "JOIN Answers ON Questions.QuestionID = Answers.AnswerGroupID " +
                "WHERE QuestionID = @questionID AND Answers.Answer = @PickedAnswer";
            using (var command = new SqlCommand(getPickedAnswerIDQuery, connection)) 
            { 
                command.Parameters.AddWithValue("@questionID", questionID);
                command.Parameters.AddWithValue("@PickedAnswer", pickedAnswer);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pickedAnswerID = reader.GetInt32(reader.GetOrdinal("AnswersID"));
                    }
                }
            }

            // 3.1.2 Zjistit ID pro ostatni odpovedi
            string getAnswersIDQuery = "SELECT Answers.AnswersID FROM Questions " +
                "JOIN Answers ON Questions.QuestionID = Answers.AnswerGroupID " +
                "WHERE QuestionID = @questionID AND Answers.Answer " +
                "IN (" + string.Join(", ", answers.Select((a, i) => $"@Answer{i}")) + ")";
            using (var command = new SqlCommand(getAnswersIDQuery, connection))
            {
                command.Parameters.AddWithValue("@questionID", questionID);
                for (int i = 0; i < answers.Length; i++)
                {
                    command.Parameters.AddWithValue($"@Answer{i}", answers[i]);
                }
                using (var reader = command.ExecuteReader())
                {
                    int index = 0;
                    while (reader.Read())
                    {
                        answersID[index] = reader.GetInt32(reader.GetOrdinal("AnswersID"));
                        index++;
                    }
                }
            }
            
            // 4. ZAPISANI STATISTIK v tabulce Answers 
            // 4.1 ZAPSANI STATISTIK zobrazenych odpovedi
            foreach (var ans in answersID)
            {
                string updateShownQuery = "UPDATE Answers SET TimesShown = TimesShown + 1 WHERE AnswersID " +
                    "IN (" + string.Join(", ", answersID.Select((a, i) => $"@answersID{i}")) + ")";
                using (var updateShownCmd = new SqlCommand(updateShownQuery, connection))
                {
                    for (int i = 0; i < answersID.Length; i++)
                    {
                        updateShownCmd.Parameters.AddWithValue($"@answersID{i}", answersID[i]);
                    }
                    updateShownCmd.ExecuteNonQuery();
                }
            }
            // 4.2 ZAPSANI STATISTIKY vybrane odpovedi
            string updatePickedQuery = "UPDATE Answers SET TimesPicked = TimesPicked + 1 WHERE AnswersID = @pickedAnswerID";
            using (var updatePickedCmd = new SqlCommand(updatePickedQuery, connection))
            {
                updatePickedCmd.Parameters.AddWithValue("@pickedAnswerID", pickedAnswerID);
                updatePickedCmd.ExecuteNonQuery();
            }
            
            Debug.WriteLine("Answers IDs: " + string.Join(", ", answersID));
        }


        public List<int> GetSelecetedQuestionsID(List<string> cathegories, int difficultyLevel)
        {
            try
            {
                // Generate parameter names for each category
                var catParams = cathegories.Select((cat, i) => $"@cat{i}").ToList();
                string inClause = string.Join(", ", catParams);

                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                string query = "SELECT DISTINCT Questions.QuestionID FROM Questions " +
                    "JOIN CathegoryGrouping ON Questions.QuestionID = CathegoryGrouping.catGroupID " +
                    "JOIN Cathegory ON CathegoryGrouping.CathegoryID = Cathegory.CathegoryID " +
                    "WHERE Questions.Difficulty = @Difficulty " +
                    $"AND Cathegory.Cat_Name IN ({inClause})";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Difficulty", difficultyLevel);
                // Add each category as a parameter
                for (int i = 0; i < cathegories.Count; i++)
                {
                    command.Parameters.AddWithValue(catParams[i], cathegories[i]);
                }

                List<int> questionIds = new List<int>();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    questionIds.Add(reader.GetInt32(reader.GetOrdinal("QuestionID")));
                }
                return questionIds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in method CheckIfCathegoryExists: {ex.Message}");
                throw new Exception("Error checking cathegory existence", ex);
            }
        }

        public List<string> GetAllCathegories()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                string query = "SELECT Cat_Name FROM Cathegory";
                using var command = new SqlCommand(query, connection);
                SqlDataReader Results = command.ExecuteReader();
                List<string> cathegories = new List<string>();
                while (Results.Read())
                {
                    cathegories.Add(Results.GetString(0));
                }
                Debug.WriteLine("Cathegories loaded successfully.");
                return cathegories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in method CheckIfCathegoryExists: {ex.Message}");
                throw new Exception("Error checking cathegory existence", ex);
            }
        }

        private string[] GetPictureTable(int pictureId)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                string query = "SELECT Description, Filepath FROM Pictures " +
                    "WHERE PictureID = @PictureID";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PictureID", pictureId);
                using var reader = command.ExecuteReader();
                string[] pictureData = new string[2];
                while (reader.Read())
                {
                    pictureData[0] = reader.GetString(reader.GetOrdinal("Description"));
                    pictureData[1] = reader.GetString(reader.GetOrdinal("Filepath"));
                }
                return pictureData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in method GetPictureTable: {ex.Message}");
                throw new Exception("Error getting picture data", ex);
            }
        }

        private List<Answer> GetAnswersTable(int AnswerGroupID)
        {
            List<Answer> answers = new List<Answer>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            // First query to fetch correct answers
            string queryCorrect = "Select Answer FROM Answers WHERE AnswerGroupID = @AnswerGroupID " +
                "AND Correct = 1;";
            using (var commandCorrect = new SqlCommand(queryCorrect, connection))
            {
                commandCorrect.Parameters.AddWithValue("@AnswerGroupID", AnswerGroupID);
                using var readerCorrect = commandCorrect.ExecuteReader();
                while (readerCorrect.Read())
                {
                    string answerText = readerCorrect.GetString(readerCorrect.GetOrdinal("Answer"));
                    answers.Add(new Answer { AnswerText = answerText, IsCorrect = true });
                }
            }

            // Second query to fetch incorrect answers
            string queryIncorrect = "Select TOP 3 Answer FROM Answers WHERE AnswerGroupID = @AnswerGroupID " +
                "AND Correct = 0 ORDER BY NEWID();";
            using (var commandIncorrect = new SqlCommand(queryIncorrect, connection))
            {
                commandIncorrect.Parameters.AddWithValue("@AnswerGroupID", AnswerGroupID);
                using var readerIncorrect = commandIncorrect.ExecuteReader();
                while (readerIncorrect.Read())
                {
                    string answerText = readerIncorrect.GetString(readerIncorrect.GetOrdinal("Answer"));
                    answers.Add(new Answer { AnswerText = answerText, IsCorrect = false });
                }
            }

            // Randomly shuffle the answers
            var rng = new Random();
            answers = answers.OrderBy(x => rng.Next()).ToList();
            return answers;
        }
    }
}
