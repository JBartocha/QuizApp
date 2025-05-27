using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{

    internal static class StatisticsFormDatabaseOperator
    {
        private static readonly string _connectionString = ConnectionString.Get();


        public static int GetTotalQuestionsAnswered()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) FROM Questions WHERE Questions.TimesShown != 0;", connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static int GetTotalCorrectAnswers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) FROM Questions WHERE Questions.TimesAnsweredCorrectly != 0;", connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static string MostAskedQuestion()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT TOP 1 Questions.Title FROM Questions ORDER BY TimesShown DESC;", connection))
                {
                    return command.ExecuteScalar()?.ToString() ?? "No questions found.";
                }
            }
        }

        public static string MostIncorrectlyAnsweredQuestion()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT TOP 1 Questions.Title FROM Questions \r\nORDER BY Questions.TimesShown - Questions.TimesAnsweredCorrectly DESC;", connection))
                {
                    return command.ExecuteScalar()?.ToString() ?? "No questions found.";
                }
            }
        }

        public static string[] MostIncorrectlyPickedAnswer()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT TOP 1 Answers.Answer, Questions.Title " +
                    "FROM Answers JOIN Questions ON Answers.AnswerGroupID = Questions.QuestionID " +
                    "WHERE Answers.Correct = 0 " +
                    "ORDER BY Answers.TimesPicked;", connection))
                {
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        // Assuming the first column is the answer and the second is the question title
                        string[] result = new string[2];
                        result[0] = reader.GetString(0);
                        result[1] = reader.GetString(1);
                        return result;
                    }
                }
                throw new Exception("No incorrect answers found.");
            }
        }
    }
}
