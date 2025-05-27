namespace QuizApp
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_TotalAnswers = new Label();
            label_TotalCorrectAnswers = new Label();
            label_MostIncorrectlyAnsweredQuestion = new Label();
            label_MostIncorrectlyPickedAnswer = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label_TotalAnswers
            // 
            label_TotalAnswers.AutoSize = true;
            label_TotalAnswers.Font = new Font("Segoe UI", 18F);
            label_TotalAnswers.Location = new Point(12, 9);
            label_TotalAnswers.Name = "label_TotalAnswers";
            label_TotalAnswers.Size = new Size(305, 32);
            label_TotalAnswers.TabIndex = 0;
            label_TotalAnswers.Text = "Pocet Celkových Odpovědí:";
            // 
            // label_TotalCorrectAnswers
            // 
            label_TotalCorrectAnswers.AutoSize = true;
            label_TotalCorrectAnswers.Font = new Font("Segoe UI", 18F);
            label_TotalCorrectAnswers.Location = new Point(11, 41);
            label_TotalCorrectAnswers.Name = "label_TotalCorrectAnswers";
            label_TotalCorrectAnswers.Size = new Size(306, 32);
            label_TotalCorrectAnswers.TabIndex = 1;
            label_TotalCorrectAnswers.Text = "Počet Správných Odpovědí:";
            // 
            // label_MostIncorrectlyAnsweredQuestion
            // 
            label_MostIncorrectlyAnsweredQuestion.AutoSize = true;
            label_MostIncorrectlyAnsweredQuestion.Font = new Font("Segoe UI", 18F);
            label_MostIncorrectlyAnsweredQuestion.ForeColor = SystemColors.ControlText;
            label_MostIncorrectlyAnsweredQuestion.Location = new Point(11, 95);
            label_MostIncorrectlyAnsweredQuestion.Name = "label_MostIncorrectlyAnsweredQuestion";
            label_MostIncorrectlyAnsweredQuestion.Size = new Size(243, 32);
            label_MostIncorrectlyAnsweredQuestion.TabIndex = 2;
            label_MostIncorrectlyAnsweredQuestion.Text = "Nejchybnější Otázka: ";
            // 
            // label_MostIncorrectlyPickedAnswer
            // 
            label_MostIncorrectlyPickedAnswer.AutoSize = true;
            label_MostIncorrectlyPickedAnswer.Font = new Font("Segoe UI", 18F);
            label_MostIncorrectlyPickedAnswer.Location = new Point(12, 127);
            label_MostIncorrectlyPickedAnswer.Name = "label_MostIncorrectlyPickedAnswer";
            label_MostIncorrectlyPickedAnswer.Size = new Size(264, 32);
            label_MostIncorrectlyPickedAnswer.TabIndex = 3;
            label_MostIncorrectlyPickedAnswer.Text = "Nejchybnější Odpověď:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(323, 9);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(308, 29);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(323, 44);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(308, 29);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F);
            textBox3.Location = new Point(323, 95);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(308, 29);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 12F);
            textBox4.Location = new Point(323, 130);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(308, 29);
            textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 12F);
            textBox5.Location = new Point(323, 165);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(308, 29);
            textBox5.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(150, 162);
            label1.Name = "label1";
            label1.Size = new Size(123, 32);
            label1.TabIndex = 9;
            label1.Text = "- z otázky:";
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label_MostIncorrectlyPickedAnswer);
            Controls.Add(label_MostIncorrectlyAnsweredQuestion);
            Controls.Add(label_TotalCorrectAnswers);
            Controls.Add(label_TotalAnswers);
            Name = "StatisticsForm";
            Text = "StatisticsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_TotalAnswers;
        private Label label_TotalCorrectAnswers;
        private Label label_MostIncorrectlyAnsweredQuestion;
        private Label label_MostIncorrectlyPickedAnswer;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
    }
}