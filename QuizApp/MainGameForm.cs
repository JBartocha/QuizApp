using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QuizApp
{

    public partial class MainGameForm : Form
    {
        Graphics _grap;
        Bitmap _surface;
        PeriodicTimer? _Timer;
        GameDatabaseOperator _GDO = new GameDatabaseOperator();
        readonly int _QuestionTime = 60;
        float _RemainingTime = 60;
        bool _answerSelected = false;
        int _currentQuestionIndex = 0;
        int _CorrectAnswers = 0;

        readonly int _QuestionTotal;
        List<Question> _Questions = new List<Question>();
        private List<int> cathegoryIDs;
        private readonly int difficulty;
        private readonly int numberOfQuestions;

        public MainGameForm(List<int> cathegoryIDs, int difficulty, int numberOfQuestions)
        {
            InitializeComponent();

            this.difficulty = difficulty;

            List<int> questionIds = new List<int>();
            questionIds = _GDO.GetSelecetedQuestionsID(cathegoryIDs, difficulty);

            // Shuffle and take random elements
            Random rng = new Random();
            List<int> randomQuestionsID = questionIds.OrderBy(x => rng.Next()).Take(numberOfQuestions).ToList();

            foreach (int questionId in randomQuestionsID)
            {
                _Questions.Add(_GDO.GetQuestion(questionId));
            }
            // If there are not enough questions, fill with empty questions
            _QuestionTotal = _Questions.Count;

            SetBufferingForMainPanel();

            _surface = new Bitmap(panel1.Width, panel1.Height);
            _grap = Graphics.FromImage(_surface);
            panel1.BackgroundImage = _surface;
            panel1.BackgroundImageLayout = ImageLayout.None;

            label_answers.Text = "Spravné odpovědi: " + _CorrectAnswers.ToString() + "/" +
                _QuestionTotal.ToString() + "(" + _currentQuestionIndex + ")";

            PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000));

            Task<bool> task = TimerForClock();

            ResetComponents();
            SetQuestion();
        }

        void SetBufferingForMainPanel()
        {
            // Buffering clocks to remove flickering
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            panel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic).SetValue(panel1, true, null);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        private void SetQuestion()
        {
            label_Title.Text = _Questions[_currentQuestionIndex].QuestionTitle;
            richTextBox1.Text = _Questions[_currentQuestionIndex].QuestionText;
            label_Time.Text = _QuestionTime.ToString();
            linkLabel.Text = _Questions[_currentQuestionIndex].QuestionLink;

            for (int i = 0; i < 4; i++)
            {
                Button? button = this.Controls.Find("button" + i, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Text = _Questions[_currentQuestionIndex].Answers[i];
                    button.Show();
                    button.Enabled = true;
                    button.BackColor = Color.FromArgb(255, 240, 240, 240); // Reset color to default
                }
            }

        }

        public async Task<bool> TimerForClock()
        {
            float time = 0;
            if (time > _QuestionTime)
            {
                return false;
            }
            _Timer = new PeriodicTimer(TimeSpan.FromMilliseconds(200));
            while (await _Timer.WaitForNextTickAsync())
            {
                _grap.DrawPie(new Pen(Color.FromArgb(255, 240, 240, 240), 5),
                    0, 0, panel1.Width - 3, panel1.Height - 3, 270, time * 6);
                panel1.Invalidate();
                time += 0.2f;

                _RemainingTime -= 0.2f;
                label_Time.Text = Math.Round(_RemainingTime).ToString();
                if (_RemainingTime <= 0)
                {
                    _Timer.Dispose();
                    panel1.Invalidate();
                    label_Time.Text = "00";
                    
                    Button? correctAnswerButton = this.Controls.Find("button" +
                        _Questions[_currentQuestionIndex].CorrentAnswer, true).FirstOrDefault() as Button;
                    if (correctAnswerButton != null)
                    {
                        correctAnswerButton.BackColor = Color.FromArgb(222, 0, 150, 0);
                    }
                   
                    _GDO.AnswerSelection(_Questions[_currentQuestionIndex].QuestionID,
                    _Questions[_currentQuestionIndex].Answers.ToArray(),
                    null);
                 
                    ShowAfterSelection();
                    return false;
                    
                }
            }
            return true;
        }

        private void ShowAfterSelection()
        {
            button_next.Show();
            if (_Questions[_currentQuestionIndex].QuestionPictureName != null
                && _Questions[_currentQuestionIndex].QuestionPictureName != "")
            {
                button_Picture.Show();
            }
            linkLabel.Show();

            _currentQuestionIndex++;
            label_answers.Text = "Spravné odpovědi: " + _CorrectAnswers.ToString() + "/" +
                        _QuestionTotal.ToString() + "(" + _currentQuestionIndex + ")";
        }

        private void ResetClock()
        {
            Brush brush1 = new SolidBrush(Color.FromArgb(255, 0, 153, 255));
            Brush brush2 = new SolidBrush(Color.FromArgb(255, 240, 240, 240));
            _grap.FillEllipse(brush1, 0, 0, panel1.Width - 1, panel1.Height - 1);
            _grap.FillEllipse(brush2, 40, 40, panel1.Width - 80, panel1.Height - 80);

            panel1.Invalidate();
            _RemainingTime = _QuestionTime;
            label_Time.Text = _QuestionTime.ToString();
        }

        private void ResetComponents()
        {
            ResetClock();

            button_Picture.Hide();
            button_next.Hide();
            linkLabel.Hide();
            linkLabel.Links.Clear();
            linkLabel.Links.Add(0, linkLabel.Text.Length);
            _answerSelected = false;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            ResetComponents();
            SetQuestion();
            Task<bool> task = TimerForClock();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string url = linkLabel.Text;
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void button_Picture_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form pictureForm = new SimplePictureForm(_Questions[_currentQuestionIndex].QuestionPictureName))
            {
                pictureForm.ShowDialog();
            }
            this.Show();
        }

        private void button_MouseClick(object sender, MouseEventArgs e)
        {
            if (_answerSelected)
                return; // Prevent multiple selections

            int selectedAnswer = -1;
            if (sender is Control control)
            {
                string name = control.Name;
                string result = Regex.Replace(name, @"[button]", "");
                selectedAnswer = int.Parse(result);
            }

            Button? button = this.Controls.Find("button" + selectedAnswer, true).FirstOrDefault() as Button;
            if (button != null)
            {
                if (selectedAnswer == _Questions[_currentQuestionIndex].CorrentAnswer)
                {
                    button.BackColor = Color.FromArgb(222, 0, 150, 0); // Green for correct answer
                    _CorrectAnswers++; // Increment correct answers count   
                }
                else
                {
                    button.BackColor = Color.FromArgb(222, 150, 0, 0); // Red for incorrect answer
                    Button? correctAnswerButton = this.Controls.Find("button" +
                        _Questions[_currentQuestionIndex].CorrentAnswer, true).FirstOrDefault() as Button;
                    if (correctAnswerButton != null)
                    {
                        correctAnswerButton.BackColor = Color.FromArgb(255, 0, 153, 0); // Green for correct answer
                    }
                }
            }

            // Sends data needed to save statistics for question and answer selection
            _GDO.AnswerSelection(_Questions[_currentQuestionIndex].QuestionID,
                _Questions[_currentQuestionIndex].Answers.ToArray(),
                _Questions[_currentQuestionIndex].Answers[selectedAnswer]);

            // Disable all buttons after selection
            _answerSelected = true;
            if (_Timer != null)
                _Timer.Dispose();

            ShowAfterSelection();

            if (_currentQuestionIndex == _QuestionTotal)
            {
                MessageBox.Show("Konec hry! Správné odpovědi: " + _CorrectAnswers + "/" + _QuestionTotal);
                this.Close(); // Or navigate to a results form
                return;
            }
        }
    }
}
