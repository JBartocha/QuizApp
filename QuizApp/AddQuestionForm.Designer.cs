namespace QuizApp
{
    partial class AddQuestionForm
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
            textBox1 = new TextBox();
            button1 = new Button();
            textBox_MainQuestionText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox_LinkAddress = new TextBox();
            button2 = new Button();
            textBox_FilePath = new TextBox();
            button3 = new Button();
            AddAnswerButton = new Button();
            label4 = new Label();
            comboBox1 = new ComboBox();
            button_CompleteQuestion = new Button();
            button_Zpet = new Button();
            button6 = new Button();
            textBox_PictureDescription = new TextBox();
            label5 = new Label();
            textBox_Title = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 18F);
            textBox1.Location = new Point(12, 347);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(504, 39);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.ImageAlign = ContentAlignment.BottomCenter;
            button1.Location = new Point(522, 347);
            button1.Name = "button1";
            button1.Size = new Size(129, 39);
            button1.TabIndex = 1;
            button1.Text = "Přidat Kategorie";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox_MainQuestionText
            // 
            textBox_MainQuestionText.Font = new Font("Segoe UI", 18F);
            textBox_MainQuestionText.Location = new Point(12, 33);
            textBox_MainQuestionText.Multiline = true;
            textBox_MainQuestionText.Name = "textBox_MainQuestionText";
            textBox_MainQuestionText.Size = new Size(1326, 224);
            textBox_MainQuestionText.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 323);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 3;
            label1.Text = "Kategorie:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(61, 21);
            label2.TabIndex = 4;
            label2.Text = "Otázka:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 389);
            label3.Name = "label3";
            label3.Size = new Size(175, 21);
            label3.TabIndex = 5;
            label3.Text = "Link k Odpovědi otázky:";
            // 
            // textBox_LinkAddress
            // 
            textBox_LinkAddress.Font = new Font("Segoe UI", 18F);
            textBox_LinkAddress.Location = new Point(12, 413);
            textBox_LinkAddress.Name = "textBox_LinkAddress";
            textBox_LinkAddress.Size = new Size(504, 39);
            textBox_LinkAddress.TabIndex = 8;
            // 
            // button2
            // 
            button2.ImageAlign = ContentAlignment.BottomCenter;
            button2.Location = new Point(12, 458);
            button2.Name = "button2";
            button2.Size = new Size(350, 39);
            button2.TabIndex = 9;
            button2.Text = "Přidat Obázek k Otázce";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox_FilePath
            // 
            textBox_FilePath.Font = new Font("Segoe UI", 12F);
            textBox_FilePath.Location = new Point(12, 503);
            textBox_FilePath.Multiline = true;
            textBox_FilePath.Name = "textBox_FilePath";
            textBox_FilePath.ReadOnly = true;
            textBox_FilePath.Size = new Size(504, 45);
            textBox_FilePath.TabIndex = 10;
            // 
            // button3
            // 
            button3.ImageAlign = ContentAlignment.BottomCenter;
            button3.Location = new Point(368, 458);
            button3.Name = "button3";
            button3.Size = new Size(148, 39);
            button3.TabIndex = 11;
            button3.Text = "Zrušit Obrázek";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // AddAnswerButton
            // 
            AddAnswerButton.Font = new Font("Segoe UI", 12F);
            AddAnswerButton.ImageAlign = ContentAlignment.BottomCenter;
            AddAnswerButton.Location = new Point(657, 284);
            AddAnswerButton.Name = "AddAnswerButton";
            AddAnswerButton.Size = new Size(681, 39);
            AddAnswerButton.TabIndex = 12;
            AddAnswerButton.Text = "Přidat řádek na další odpověď";
            AddAnswerButton.UseVisualStyleBackColor = true;
            AddAnswerButton.Click += AddAnswerButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 641);
            label4.Name = "label4";
            label4.Size = new Size(132, 21);
            label4.TabIndex = 14;
            label4.Text = "Obtížnost Otázky:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(150, 641);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(366, 23);
            comboBox1.TabIndex = 15;
            // 
            // button_CompleteQuestion
            // 
            button_CompleteQuestion.ImageAlign = ContentAlignment.BottomCenter;
            button_CompleteQuestion.Location = new Point(12, 678);
            button_CompleteQuestion.Name = "button_CompleteQuestion";
            button_CompleteQuestion.Size = new Size(164, 39);
            button_CompleteQuestion.TabIndex = 16;
            button_CompleteQuestion.Text = "Pridat Otazku";
            button_CompleteQuestion.UseVisualStyleBackColor = true;
            button_CompleteQuestion.Click += button_CompeteQuestionClick;
            // 
            // button_Zpet
            // 
            button_Zpet.ImageAlign = ContentAlignment.BottomCenter;
            button_Zpet.Location = new Point(352, 678);
            button_Zpet.Name = "button_Zpet";
            button_Zpet.Size = new Size(164, 39);
            button_Zpet.TabIndex = 17;
            button_Zpet.Text = "Zpet";
            button_Zpet.UseVisualStyleBackColor = true;
            button_Zpet.Click += button5_Click;
            // 
            // button6
            // 
            button6.ImageAlign = ContentAlignment.BottomCenter;
            button6.Location = new Point(182, 678);
            button6.Name = "button6";
            button6.Size = new Size(164, 39);
            button6.TabIndex = 18;
            button6.Text = "Pridat Otazku z Retezce";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            // 
            // textBox_PictureDescription
            // 
            textBox_PictureDescription.Font = new Font("Segoe UI", 18F);
            textBox_PictureDescription.Location = new Point(12, 579);
            textBox_PictureDescription.Name = "textBox_PictureDescription";
            textBox_PictureDescription.Size = new Size(504, 39);
            textBox_PictureDescription.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 551);
            label5.Name = "label5";
            label5.Size = new Size(113, 21);
            label5.TabIndex = 20;
            label5.Text = "Popis Obrázku:";
            // 
            // textBox_Title
            // 
            textBox_Title.Font = new Font("Segoe UI", 18F);
            textBox_Title.Location = new Point(12, 284);
            textBox_Title.Name = "textBox_Title";
            textBox_Title.Size = new Size(504, 39);
            textBox_Title.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 260);
            label6.Name = "label6";
            label6.Size = new Size(107, 21);
            label6.TabIndex = 22;
            label6.Text = "TitulekOtazky:";
            // 
            // AddQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(label6);
            Controls.Add(textBox_Title);
            Controls.Add(label5);
            Controls.Add(textBox_PictureDescription);
            Controls.Add(button6);
            Controls.Add(button_Zpet);
            Controls.Add(button_CompleteQuestion);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(AddAnswerButton);
            Controls.Add(button3);
            Controls.Add(textBox_FilePath);
            Controls.Add(button2);
            Controls.Add(textBox_LinkAddress);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_MainQuestionText);
            Controls.Add(button1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddQuestionForm";
            Text = "AddQuestionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TextBox textBox_MainQuestionText;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox_LinkAddress;
        private Button button2;
        private TextBox textBox_FilePath;
        private Button button3;
        private Button AddAnswerButton;
        private Label label4;
        private ComboBox comboBox1;
        private Button button_CompleteQuestion;
        private Button button_Zpet;
        private Button button6;
        private TextBox textBox_PictureDescription;
        private Label label5;
        private TextBox textBox_Title;
        private Label label6;
    }
}