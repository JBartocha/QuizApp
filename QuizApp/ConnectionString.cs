using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal static class ConnectionString
    {
        public static string Get()
        {
            string dbFilename = Environment.CurrentDirectory;
            for (int i = 0; i < 3; i++)
            {
                dbFilename = Directory.GetParent(dbFilename)?.ToString() ??
                    throw new InvalidOperationException("Parent directory is null.");
            }
            dbFilename += "\\MainDatabase.mdf";

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = dbFilename,
                IntegratedSecurity = true
            };
            return builder.ConnectionString;
        }

    }
}
