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
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(button_next);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(12, 614);
            panel2.Name = "panel2";
            panel2.Size = new Size(1316, 103);
            panel2.TabIndex = 1;
            // 
            // button_next
            // 
            button_next.Location = new Point(1176, 28);
            button_next.Name = "button_next";
            button_next.Size = new Size(137, 49);
            button_next.TabIndex = 4;
            button_next.Text = "5";
            button_next.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(779, 28);
            button4.Name = "button4";
            button4.Size = new Size(137, 49);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.MouseCaptureChanged += button1_MouseCaptureChanged;
            // 
            // button3
            // 
            button3.Location = new Point(636, 28);
            button3.Name = "button3";
            button3.Size = new Size(137, 49);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.MouseCaptureChanged += button1_MouseCaptureChanged;
            // 
            // button2
            // 
            button2.Location = new Point(493, 28);
            button2.Name = "button2";
            button2.Size = new Size(137, 49);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.MouseCaptureChanged += button1_MouseCaptureChanged;
            // 
            // button1
            // 
            button1.Location = new Point(350, 28);
            button1.Name = "button1";
            button1.Size = new Size(137, 49);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.MouseCaptureChanged += button1_MouseCaptureChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(11, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1313, 378);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.Location = new Point(542, 396);
            panel1.Name = "panel1";
            panel1.Size = new Size(212, 212);
            panel1.TabIndex = 4;
            // 
            // MainGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(panel1);
            Controls.Add(richTextBox1);
            Controls.Add(panel2);
            Name = "MainGameForm";
            Text = "MainGameForm";
            panel2.ResumeLayout(false);
            ResumeLayout(false);
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
    }
}