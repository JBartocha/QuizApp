namespace QuizApp
{
    partial class MainGameForm
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
            panel2 = new Panel();
            button_next = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            label_Time = new Label();
            label_Title = new Label();
            label_Difficulty = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(button_next);
            panel2.Location = new Point(12, 614);
            panel2.Name = "panel2";
            panel2.Size = new Size(1326, 103);
            panel2.TabIndex = 1;
            // 
            // button_next
            // 
            button_next.Location = new Point(1114, 3);
            button_next.Name = "button_next";
            button_next.Size = new Size(209, 97);
            button_next.TabIndex = 4;
            button_next.Text = "5";
            button_next.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(572, 505);
            button4.Name = "button4";
            button4.Size = new Size(548, 103);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.MouseCaptureChanged += button1_MouseCaptureChanged;
            // 
            // button3
            // 
            button3.Location = new Point(572, 396);
            button3.Name = "button3";
            button3.Size = new Size(548, 104);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.MouseCaptureChanged += button1_MouseCaptureChanged;
            // 
            // button2
            // 
            button2.Location = new Point(12, 506);
            button2.Name = "button2";
            button2.Size = new Size(548, 104);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.MouseCaptureChanged += button1_MouseCaptureChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 396);
            button1.Name = "button1";
            button1.Size = new Size(548, 104);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.MouseCaptureChanged += button1_MouseCaptureChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 44);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1326, 346);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(label_Time);
            panel1.Location = new Point(1126, 396);
            panel1.Name = "panel1";
            panel1.Size = new Size(212, 212);
            panel1.TabIndex = 4;
            // 
            // label_Time
            // 
            label_Time.AutoSize = true;
            label_Time.BackColor = Color.Transparent;
            label_Time.Font = new Font("Segoe UI", 72F);
            label_Time.Location = new Point(30, 35);
            label_Time.Name = "label_Time";
            label_Time.Size = new Size(158, 128);
            label_Time.TabIndex = 0;
            label_Time.Text = "60";
            // 
            // label_Title
            // 
            label_Title.AutoSize = true;
            label_Title.Font = new Font("Segoe UI", 18F);
            label_Title.Location = new Point(12, 9);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(110, 32);
            label_Title.TabIndex = 5;
            label_Title.Text = "Title Text";
            // 
            // label_Difficulty
            // 
            label_Difficulty.AutoSize = true;
            label_Difficulty.Font = new Font("Segoe UI", 18F);
            label_Difficulty.Location = new Point(1052, 9);
            label_Difficulty.Name = "label_Difficulty";
            label_Difficulty.Size = new Size(228, 32);
            label_Difficulty.TabIndex = 6;
            label_Difficulty.Text = "Obtížnost: obtížnost";
            // 
            // MainGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(label_Difficulty);
            Controls.Add(button4);
            Controls.Add(label_Title);
            Controls.Add(button3);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(panel2);
            Name = "MainGameForm";
            Text = "MainGameForm";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private Button button_next;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private RichTextBox richTextBox1;
        private Panel panel1;
        private Label label_Title;
        private Label label_Difficulty;
        private Label label_Time;
    }
}