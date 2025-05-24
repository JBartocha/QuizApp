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

namespace QuizApp
{
    
    public partial class MainGameForm : Form
    {
        Graphics _grap;
        Bitmap _surface;
        PeriodicTimer _Timer;
        readonly int _QuestionTime = 60;
        float _RemainingTime = 60;
        bool _answerSelected = false;
        
        Question _question = new Question();
        GameDatabaseOperator _GDO = new GameDatabaseOperator();

        public MainGameForm()
        {
            InitializeComponent();

            List<string> cathegories = new List<string> { "Mars", "venus", "i dont exists" };
            List<int> questionIds = new List<int>();
            questionIds = _GDO.GetSelecetedQuestionsID(cathegories, 3);

            /*
            // Assume you have your list of ints
            List<int> allIds = new List<int>();

            // Shuffle and take 10 random elements
            Random rng = new Random();
            List<int> randomTen = allIds.OrderBy(x => rng.Next()).Take(10).ToList();
            */

            Question q = _GDO.GetQuestion(3);

            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            panel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic).SetValue(panel1, true, null);
            #pragma warning restore CS8602 // Dereference of a possibly null reference.

            _surface = new Bitmap(panel1.Width, panel1.Height);
            _grap = Graphics.FromImage(_surface);
            panel1.BackgroundImage = _surface;
            panel1.BackgroundImageLayout = ImageLayout.None;

            Color c = panel1.BackColor;
            Debug.WriteLine("R:" + c.R + " G:" + c.G + " B:" + c.B);

            Brush brush1 = new SolidBrush(Color.FromArgb(255, 0, 153, 255));
            Brush brush2 = new SolidBrush(Color.FromArgb(255, 240, 240, 240));

            _grap.FillEllipse(brush1, 0, 0, panel1.Width - 1, panel1.Height - 1);
            _grap.FillEllipse(brush2, 40, 40, panel1.Width - 80, panel1.Height - 80);
            panel1.Invalidate();
            PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000));
            
            button_next.Hide();

            Task<bool> task = TurnPeriodicTimer();

        }

        public async Task<bool> TurnPeriodicTimer()
        {
            float time = 0;
            if(time > _QuestionTime)
            {
                return false;
            }
            _Timer = new PeriodicTimer(TimeSpan.FromMilliseconds(200));
            while (await _Timer.WaitForNextTickAsync())
            {
                _grap.DrawPie(new Pen(Color.FromArgb(255,240,240,240), 5),
                    0, 0, panel1.Width - 3, panel1.Height - 3, 270, time*6);
                panel1.Invalidate();
                time += 0.2f;

                _RemainingTime -= 0.2f;
                label_Time.Text = Math.Round(_RemainingTime).ToString();
                if(_RemainingTime <= 0)
                {
                    _Timer.Dispose();
                    panel1.Invalidate();
                    label_Time.Text = "00";
                    //TODO : Dodelat
                    button_next.Show();
                    return false;
                }
            }
            return true;
        }

        private void button1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                Debug.WriteLine(control.Name);
            }
            _answerSelected = true;
            button_next.Show();
        }
    }
}
