namespace QuizApp
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_Start = new Button();
            buttonStatistics = new Button();
            button_AddQuestion = new Button();
            button_Exit = new Button();
            SuspendLayout();
            // 
            // button_Start
            // 
            button_Start.Font = new Font("Segoe UI", 18F);
            button_Start.Location = new Point(279, 39);
            button_Start.Name = "button_Start";
            button_Start.Size = new Size(198, 40);
            button_Start.TabIndex = 0;
            button_Start.Text = "Začni Kvíz";
            button_Start.UseVisualStyleBackColor = true;
            button_Start.Click += button_BeginQuiz_Click;
            // 
            // buttonStatistics
            // 
            buttonStatistics.Font = new Font("Segoe UI", 18F);
            buttonStatistics.Location = new Point(279, 131);
            buttonStatistics.Name = "buttonStatistics";
            buttonStatistics.Size = new Size(198, 40);
            buttonStatistics.TabIndex = 1;
            buttonStatistics.Text = "Statistiky";
            buttonStatistics.UseVisualStyleBackColor = true;
            buttonStatistics.Click += buttonStatistics_Click;
            // 
            // button_AddQuestion
            // 
            button_AddQuestion.Font = new Font("Segoe UI", 18F);
            button_AddQuestion.Location = new Point(279, 85);
            button_AddQuestion.Name = "button_AddQuestion";
            button_AddQuestion.Size = new Size(198, 40);
            button_AddQuestion.TabIndex = 2;
            button_AddQuestion.Text = "Přidej Otázku";
            button_AddQuestion.UseVisualStyleBackColor = true;
            button_AddQuestion.Click += button_AddQuestion_Click;
            // 
            // button_Exit
            // 
            button_Exit.Font = new Font("Segoe UI", 18F);
            button_Exit.Location = new Point(279, 370);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(198, 40);
            button_Exit.TabIndex = 3;
            button_Exit.Text = "Exit";
            button_Exit.UseVisualStyleBackColor = true;
            button_Exit.Click += button_Exit_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_Exit);
            Controls.Add(button_AddQuestion);
            Controls.Add(buttonStatistics);
            Controls.Add(button_Start);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button button_Start;
        private Button buttonStatistics;
        private Button button_AddQuestion;
        private Button button_Exit;
    }
}
