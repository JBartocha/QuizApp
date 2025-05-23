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
        bool _answerSelected = false;

        public MainGameForm()
        {
            InitializeComponent();
            richTextBox1.Font = new Font("Arial", 24, FontStyle.Regular);
            richTextBox1.Text = "This is a test text that should be cut off if it is too long. " +
                "This is a test text that should be cut off if it is too long. " +
                "This is a test text that should be cut off if it is too long. " +
                "This is a test text that should be cut off if it is too long. " +
                "This is a test text that should be cut off if it is too long. " +
                "This is a test text that should be cut off if it is too long. ";
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
