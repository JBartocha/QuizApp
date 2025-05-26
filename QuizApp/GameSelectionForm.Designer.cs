namespace QuizApp
{
    partial class GameSelectionForm
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
            comboBox1 = new ComboBox();
            button_Back = new Button();
            button_BeginGame = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox_NumberOfQuestions = new ComboBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 18F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1084, 624);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(254, 40);
            comboBox1.TabIndex = 0;
            // 
            // button_Back
            // 
            button_Back.Font = new Font("Segoe UI", 18F);
            button_Back.Location = new Point(12, 670);
            button_Back.Name = "button_Back";
            button_Back.Size = new Size(180, 47);
            button_Back.TabIndex = 1;
            button_Back.Text = "Zpět";
            button_Back.UseVisualStyleBackColor = true;
            button_Back.Click += button_Back_Click;
            // 
            // button_BeginGame
            // 
            button_BeginGame.Font = new Font("Segoe UI", 18F);
            button_BeginGame.Location = new Point(1158, 670);
            button_BeginGame.Name = "button_BeginGame";
            button_BeginGame.Size = new Size(180, 47);
            button_BeginGame.TabIndex = 2;
            button_BeginGame.Text = "Začni Kvíz";
            button_BeginGame.UseVisualStyleBackColor = true;
            button_BeginGame.Click += button_BeginGame_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(956, 627);
            label1.Name = "label1";
            label1.Size = new Size(122, 32);
            label1.TabIndex = 3;
            label1.Text = "Obtížnost:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(219, 32);
            label2.TabIndex = 4;
            label2.Text = "Témata (Kategorie):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(920, 581);
            label3.Name = "label3";
            label3.Size = new Size(158, 32);
            label3.TabIndex = 6;
            label3.Text = "Počet Otázek:";
            // 
            // comboBox_NumberOfQuestions
            // 
            comboBox_NumberOfQuestions.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_NumberOfQuestions.Font = new Font("Segoe UI", 18F);
            comboBox_NumberOfQuestions.FormattingEnabled = true;
            comboBox_NumberOfQuestions.Items.AddRange(new object[] { "5", "6", "7", "8" });
            comboBox_NumberOfQuestions.Location = new Point(1084, 578);
            comboBox_NumberOfQuestions.Name = "comboBox_NumberOfQuestions";
            comboBox_NumberOfQuestions.Size = new Size(254, 40);
            comboBox_NumberOfQuestions.TabIndex = 5;
            // 
            // GameSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(label3);
            Controls.Add(comboBox_NumberOfQuestions);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_BeginGame);
            Controls.Add(button_Back);
            Controls.Add(comboBox1);
            Name = "GameSelectionForm";
            Text = "GameSelectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button button_Back;
        private Button button_BeginGame;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox_NumberOfQuestions;
    }
}