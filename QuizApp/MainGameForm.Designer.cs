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
            button_Picture = new Button();
            linkLabel = new LinkLabel();
            button_next = new Button();
            button1 = new Button();
            button3 = new Button();
            button2 = new Button();
            button0 = new Button();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            label_Time = new Label();
            label_Title = new Label();
            label_Difficulty = new Label();
            label_answers = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(button_Picture);
            panel2.Controls.Add(linkLabel);
            panel2.Location = new Point(12, 614);
            panel2.Name = "panel2";
            panel2.Size = new Size(1108, 103);
            panel2.TabIndex = 1;
            // 
            // button_Picture
            // 
            button_Picture.Location = new Point(3, 3);
            button_Picture.Name = "button_Picture";
            button_Picture.Size = new Size(89, 76);
            button_Picture.TabIndex = 1;
            button_Picture.Text = "Picture";
            button_Picture.UseVisualStyleBackColor = true;
            button_Picture.Click += button_Picture_Click;
            // 
            // linkLabel
            // 
            linkLabel.AccessibleName = "";
            linkLabel.AutoSize = true;
            linkLabel.LinkArea = new LinkArea(0, 10);
            linkLabel.Location = new Point(3, 82);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new Size(60, 15);
            linkLabel.TabIndex = 0;
            linkLabel.TabStop = true;
            linkLabel.Text = "linkLabel1";
            linkLabel.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button_next
            // 
            button_next.Location = new Point(1129, 614);
            button_next.Name = "button_next";
            button_next.Size = new Size(209, 103);
            button_next.TabIndex = 4;
            button_next.Text = "NEXT";
            button_next.UseVisualStyleBackColor = true;
            button_next.Click += button_next_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 24F);
            button1.Location = new Point(12, 504);
            button1.Name = "button1";
            button1.Size = new Size(551, 104);
            button1.TabIndex = 3;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += button_MouseClick;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 24F);
            button3.Location = new Point(569, 504);
            button3.Name = "button3";
            button3.Size = new Size(551, 104);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.MouseClick += button_MouseClick;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 24F);
            button2.Location = new Point(569, 396);
            button2.Name = "button2";
            button2.Size = new Size(551, 104);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.MouseClick += button_MouseClick;
            // 
            // button0
            // 
            button0.Font = new Font("Segoe UI", 24F);
            button0.Location = new Point(12, 396);
            button0.Name = "button0";
            button0.Size = new Size(551, 104);
            button0.TabIndex = 0;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.MouseClick += button_MouseClick;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 18F);
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
            // label_answers
            // 
            label_answers.AutoSize = true;
            label_answers.Font = new Font("Segoe UI", 18F);
            label_answers.Location = new Point(704, 9);
            label_answers.Name = "label_answers";
            label_answers.Size = new Size(213, 32);
            label_answers.TabIndex = 7;
            label_answers.Text = "Správné odpovědi:";
            // 
            // MainGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(label_answers);
            Controls.Add(button_next);
            Controls.Add(label_Difficulty);
            Controls.Add(button1);
            Controls.Add(label_Title);
            Controls.Add(button3);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(button0);
            Controls.Add(panel2);
            Name = "MainGameForm";
            Text = "MainGameForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private Button button_next;
        private Button button1;
        private Button button3;
        private Button button2;
        private Button button0;
        private RichTextBox richTextBox1;
        private Panel panel1;
        private Label label_Title;
        private Label label_Difficulty;
        private Label label_Time;
        private LinkLabel linkLabel;
        private Button button_Picture;
        private Label label_answers;
    }
}