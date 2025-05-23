using System;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using QuizApp;

public class AddQuestionDatabaseOperator
{
    private readonly string _connectionString = "";

    public AddQuestionDatabaseOperator()
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
        Debug.WriteLine(_connectionString);
    }

    private int? CheckIfCathegoryExists(string CathegoryName)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = "SELECT CathegoryID FROM Cathegory WHERE Cat_Name = @CathegoryName";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CathegoryName", CathegoryName);
            int? count = (int?)command.ExecuteScalar();
            if (count.HasValue)
            {
                // Cathegory exists, return its ID
                return count.Value;
            }
            else
            {
                // Cathegory does not exist, return null
                Debug.WriteLine(CathegoryName + " neexistuje");
                return null;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred in method CheckIfCathegoryExists: {ex.Message}");
            throw new Exception("Error checking cathegory existence", ex);
        }
    }
    internal int CreateNewCathegory(string CathegoryName)
    {

        int? catExists = CheckIfCathegoryExists(CathegoryName);
        if (catExists.HasValue && catExists.Value > 0)
        {
            Debug.WriteLine(CathegoryName + " existuje");
            return catExists.Value; // Cathegory already exists, no need to insert again
        }

        Debug.WriteLine(CathegoryName);

        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            // Replace "YourTable" and "ColumnName" with your actual table and column names
            string query = "INSERT INTO Cathegory (Cat_Name) VALUES (@Cat_name); SELECT SCOPE_IDENTITY();";
            using var command = new SqlCommand(query, connection);

            // Add parameter to prevent SQL injection
            command.Parameters.AddWithValue("@Cat_Name", CathegoryName);

            // Execute the query and retrieve the last inserted ID
            object result = command.ExecuteScalar();
            int LastFoodSettingsID = Convert.ToInt32(result);

            return LastFoodSettingsID;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred in method CreateNewCathegory: {ex.Message}");
            throw new Exception("Error inserting Cathegory into database", ex);
        }
    }

    internal void CreateNewQuestion(Question question)
    {
        int LastPicturesID = -1;
        int QuestionID = -1;

        // 1.PICTURE INSERTION
        if (question.QuestionPictureName != null)
        {
            LastPicturesID = Add_PictureTable_Insert(question);
        }
        // 2.QUESTION INSERTION
        QuestionID = Add_QuestionTable_Insert(question.QuestionTitle, question.QuestionText,
            question.QuestionDifficulty, question.QuestionLink, LastPicturesID);

        // 3.ANSWERS INSERTION
        for(int i = 0; i < question.Answers.Count; i++)
        {
            if (i == question.CorrentAnswer)
            {
                Add_AnswerTable_Insert(QuestionID, question.Answers[i], true);
            }
            else
            {
                Add_AnswerTable_Insert(QuestionID, question.Answers[i], false);
            }
        }

        // 4.CATHEGORY INSERTION
        int[] CathegoryID = new int[question.QuestionCathegories.Count];
        for (int i = 0; i < question.QuestionCathegories.Count; i++)
        {
            int? catID = CheckIfCathegoryExists(question.QuestionCathegories[i]);
            if (catID.HasValue && catID.Value > 0)
            {
                CathegoryID[i] = catID.Value; // Cathegory already exists, no need to insert again
            }
            else
            {
                CathegoryID[i] = Add_CathegoryTable_Insert(question.QuestionCathegories[i]);
            }
        }

        // 5.CATHEGORY GROUP INSERTION
        for (int i = 0; i < question.QuestionCathegories.Count; i++)
        {
            Add_CathegoryGroupTable_Insert(QuestionID, CathegoryID[i]);
        }
    }

    private void Add_CathegoryGroupTable_Insert(int QuestionID, int CathegoryID)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = "INSERT INTO CathegoryGrouping (CatGroupID, CathegoryID) " +
                "VALUES (@CatGroupID, @CathegoryID);";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CatGroupID", QuestionID);
            command.Parameters.AddWithValue("@CathegoryID", CathegoryID);
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred in method Add_CathegoryGroupTable_Insert: {ex.Message}");
            throw new Exception("Error inserting cathegory group into database", ex);
        }
    }

    private int Add_CathegoryTable_Insert(string CathegoryName)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = "INSERT INTO Cathegory (Cat_Name) VALUES (@Cat_Name); SELECT SCOPE_IDENTITY();";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Cat_Name", CathegoryName);
            object result = command.ExecuteScalar();
            int LastCathegoryID = Convert.ToInt32(result);
            return LastCathegoryID;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred in method Add_CathegoryTable_Insert: {ex.Message}");
            throw new Exception("Error inserting cathegory into database", ex);
        }
    }

    private void Add_AnswerTable_Insert(int AnswerGroupID, string Answer, bool Correct)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO Answers (AnswerGroupID, Answer, Correct) " +
                "VALUES (@AnswerGroupID, @Answer, @Correct);" +
                    "SELECT SCOPE_IDENTITY();";
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AnswerGroupID", AnswerGroupID);
            command.Parameters.AddWithValue("@Answer", Answer);
            command.Parameters.AddWithValue("@Correct", Correct);

            object result = command.ExecuteScalar();
            int IDAnswer = Convert.ToInt32(result);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred in method Add_AnswerTable_Insert: {ex.Message}");
            throw new Exception("Error inserting answer into database", ex);
        }
    }

    private int Add_QuestionTable_Insert(string title, string text, int difficulty, string link, int? pictureID)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "INSERT INTO Questions (Title, Question, Difficulty, PictureID, Link) " +
            "VALUES (@Title, @Question, @Difficulty, @PictureID,@Link);" +
                "SELECT SCOPE_IDENTITY();";
        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Title", title);
        command.Parameters.AddWithValue("@Question", text);
        command.Parameters.AddWithValue("@Difficulty", difficulty);
        command.Parameters.AddWithValue("@PictureID", pictureID ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@Link", link);

        object result = command.ExecuteScalar();
        int QuestionID = Convert.ToInt32(result);
        return QuestionID;
    }
    private int Add_PictureTable_Insert(Question question)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO Pictures (Description, Filepath) VALUES (@Description, @Filepath);" +
                "SELECT SCOPE_IDENTITY();";
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Description", question.QuestionPictureDescription);
            command.Parameters.AddWithValue("@Filepath", question.QuestionPictureName);

            object result = command.ExecuteScalar();
            int LastPicturesID = Convert.ToInt32(result);

            return LastPicturesID;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred in method CreateNewQuestion: {ex.Message}");
            throw new Exception("Error inserting picture into database", ex);
        }
    }

}











