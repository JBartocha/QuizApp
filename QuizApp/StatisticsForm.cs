using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(StatisticsFormDatabaseOperator.GetTotalQuestionsAnswered());
            //label_TotalAnswers.Text = "Total Questions Answered: ";
            textBox2.Text = Convert.ToString(StatisticsFormDatabaseOperator.GetTotalCorrectAnswers());
            //label_TotalCorrectAnswers.Text = "Total Correct Answers: " + 
            textBox3.Text = StatisticsFormDatabaseOperator.MostIncorrectlyAnsweredQuestion();
            //label_MostIncorrectlyAnsweredQuestion.Text = "Most Incorrectly Answered Question: " + 
            
            string[] answer = StatisticsFormDatabaseOperator.MostIncorrectlyPickedAnswer();
            
            textBox4.Text = answer[0];
            textBox5.Text = answer[1]; 
            //label_MostIncorrectlyPickedAnswer.Text = "Most Incorrectly Picked Answer: " + answer[0] + " from question: " + answer[1];
        }
    }
}
