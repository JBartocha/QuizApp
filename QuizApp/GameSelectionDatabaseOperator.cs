using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class GameSelectionDatabaseOperator
    {
        private readonly string _connectionString = "";

        public GameSelectionDatabaseOperator()
        {
            _connectionString = ConnectionString.Get();
        }

        public Dictionary<string, int> Get_All_Cathegories_FromDB()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                string query = "SELECT CathegoryID, Cat_Name FROM Cathegory";

                using var command = new SqlCommand(query, connection);

                Dictionary<string, int> Cathegories = new();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int CatID = reader.GetInt32(reader.GetOrdinal("CathegoryID"));
                    string CatName = reader.GetString(reader.GetOrdinal("Cat_Name"));
                    Cathegories.Add(CatName, CatID);
                }
                return Cathegories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in method Get_All_Cathegories_FromDB: {ex.Message}");
                throw new Exception("An error occurred in method Get_All_Cathegories_FromDB", ex);
            }
        }
    }
}
