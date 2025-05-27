namespace QuizApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button_BeginQuiz_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form GameSelectionForm = new GameSelectionForm())
            {
                GameSelectionForm.ShowDialog();
            }
            this.Show();    
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_AddQuestion_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form questForm = new AddQuestionForm())
            {
                questForm.ShowDialog();
            }
            this.Show();
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form statisticsForm = new StatisticsForm())
            {
                statisticsForm.ShowDialog();
            }
            this.Show();
        }
    }
}
