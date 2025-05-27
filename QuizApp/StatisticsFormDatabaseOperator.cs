using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{

    internal class StatisticsFormDatabaseOperator
    {
        private readonly string _connectionString = "";

        public StatisticsFormDatabaseOperator()
        {
            _connectionString = ConnectionString.Get();
        }

    }
}
