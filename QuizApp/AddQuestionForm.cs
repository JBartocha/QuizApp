using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuizApp
{
    public partial class AddQuestionForm : Form
    {

        private static int _numberOfAnswers = 0;
        AddQuestionDatabaseOperator dbOperator = new AddQuestionDatabaseOperator();

        private static Dictionary<string, System.Windows.Forms.TextBox> _AnswerBoxes =
            new Dictionary<string, System.Windows.Forms.TextBox>();

        private static Dictionary<string, System.Windows.Forms.CheckBox> _AnswerCheckBoxes =
            new Dictionary<string, System.Windows.Forms.CheckBox>();

        private static Dictionary<string, int> _DifficultChoices = new Dictionary<string, int>
            {
            { "Lehká", 3 },
            { "Střední", 5 },
            { "Těžká", 7 },
            };

        public AddQuestionForm()
        {
            InitializeComponent();

            SetComponents();

            setDefaultValues();
        }

        private void setDefaultValues()
        {
            textBox_MainQuestionText.Text = "Toto je testovací otázka, která by měla být oříznuta, pokud je příliš dlouhá. " +
                "Toto je testovací otázka, která by měla být oříznuta, pokud je příliš dlouhá. " +
                "Toto je testovací otázka, která by měla být oříznuta, pokud je příliš dlouhá. " +
                "Toto je testovací otázka, která by měla být oříznuta, pokud je příliš dlouhá. " +
                "Toto je testovací otázka, která by měla být oříznuta, pokud je příliš dlouhá. " +
                "Toto je testovací otázka, která by měla být oříznuta, pokud je příliš dlouhá.";
            textBox1.Text = "Venus,Mars";
            textBox_LinkAddress.Text = "https://www.google.com/";
            textBox_PictureDescription.Text = "This is a test description for the image.";
            textBox_FilePath.Text = "C:\\Users\\Janba\\Pictures\\a5j3K1Jb_700w_0.jpg";
            textBox_Title.Text = "Test Title";
            for(int i = 1; i <= 4; i++)
            {
                _AnswerBoxes["AnswerTextBox" + i.ToString()].Text = "Test answer " + i.ToString() + ".";
            }
        }

        private void SetComponents()
        {
            for (int i = 1; i <= 4; i++)
            {
                AddAnswerTextBox(i);
            }
            AddAnswerButton.Location = new Point(658, 284 + _numberOfAnswers * 57);

            foreach (var choice in _DifficultChoices)
            {
                comboBox1.Items.Add(choice.Key);
            }
        }

        private void AddAnswerTextBox(int AnswerNum)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Location = new Point(1221, 295 + _numberOfAnswers * 57);
            checkBox.Name = "AnswerCheckBox" + AnswerNum.ToString();
            checkBox.Text = "Correct answer"; // Added text for the checkbox
            checkBox.AutoSize = true;
            checkBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox.CheckedChanged += CheckBox_CheckedChanged; // Event handler for checkbox
            if (_numberOfAnswers == 0)
            {
                checkBox.Checked = true; // Set the first checkbox to checked by default
            }

            System.Windows.Forms.TextBox TB = new System.Windows.Forms.TextBox();
            TB.Location = new Point(658, 284 + _numberOfAnswers * 57);
            TB.Size = new Size(560, 39); //680 without checkbox
            TB.Multiline = true;
            TB.Name = "AnswerTextBox" + AnswerNum.ToString();

            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Location = new Point(658, 263 + _numberOfAnswers * 57);
            label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label.Name = "AnswerLabel" + AnswerNum.ToString();
            label.Text = $"Answer {AnswerNum}:"; // Added text for the label

            this.Controls.Add(label);
            this.Controls.Add(TB);
            this.Controls.Add(checkBox);

            _AnswerCheckBoxes.Add("AnswerCheckBox" + AnswerNum.ToString(), checkBox);
            _AnswerBoxes.Add("AnswerTextBox" + AnswerNum.ToString(), TB);
            _numberOfAnswers++;
        }

        private List<string>? TestQuestionFilled()
        {
            List<string>? Errors = new List<string>();
            if (textBox_MainQuestionText.Text == string.Empty)
            {
                Errors.Add("Question is empty.");
            }
            if (textBox1.Text.IsNullOrEmpty())
            {
                Errors.Add("Category is empty.");
            }
            if (textBox_LinkAddress.Text.IsNullOrEmpty())
            {
                Errors.Add("Link with info address is empty.");
            }
            //else if (!Uri.IsWellFormedUriString(textBox_LinkAddress.Text, UriKind.Absolute))
            //{
            //    Errors.Add("Link with info address is not valid.");
            //}
            if (comboBox1.SelectedItem == null)
            {
                Errors.Add("Difficulty is not selected.");
            }
            for (int i = 1; i <= _numberOfAnswers; i++)
            {
                if (_AnswerBoxes["AnswerTextBox" + i.ToString()].Text.IsNullOrEmpty())
                {
                    Errors.Add("Answer " + i.ToString() + " is empty.");
                }
            }
            if(textBox_FilePath.Text.IsNullOrEmpty() != textBox_PictureDescription.Text.IsNullOrEmpty())
            {
                Errors.Add("If you add image or description to image - both have to be filled");
            }
            return Errors;
        }

        private void CheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            //TODO -    aby se zabranilo zacykleni tak jsou odebrane vsechny
            //          checkboxy eventy a pak se prida zpet
            //          ale to je blbost, protoze to je zbytecne slozite - zatim nevim alternativu
            if (sender == null) return; // Check if sender is null
            for (int i = 1; i <= _numberOfAnswers; i++)
            {
                _AnswerCheckBoxes["AnswerCheckBox" + i.ToString()].CheckedChanged -= CheckBox_CheckedChanged; // Unsubscribe from the event to prevent recursion
            }

            for (int i = 1; i <= _numberOfAnswers; i++)
            {
                if (sender.Equals(_AnswerCheckBoxes["AnswerCheckBox" + i.ToString()]) == true)
                {
                    if (_AnswerCheckBoxes["AnswerCheckBox" + i.ToString()].Checked == true)
                    {
                        for (int j = 1; j <= _numberOfAnswers; j++)
                        {
                            if (j != i)
                            {
                                _AnswerCheckBoxes["AnswerCheckBox" + j.ToString()].Checked = false;
                            }
                        }
                    }
                    else
                    {
                        _AnswerCheckBoxes["AnswerCheckBox" + i.ToString()].Checked = true;
                    }
                }
            }

            for (int i = 1; i <= _numberOfAnswers; i++)
            {
                _AnswerCheckBoxes["AnswerCheckBox" + i.ToString()].CheckedChanged += CheckBox_CheckedChanged; // Subscribe back to the event
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            string CathegoryBoxText = textBox1.Text;
            List<string> Cathegories = CathegoryBoxText.Split(',').ToList();
            foreach (string cathegory in Cathegories)
            {
                dbOperator.CreateNewCathegory(cathegory);
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.Title = "Select picture in .jpeg,.png,.jpg or .bmp";
            fd.Filter = "Image Files|*.jpeg;*.jpg;*.png;*.bmp";
            fd.ShowDialog();
            textBox_FilePath.Text = fd.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // pro zruseni obrazku
            textBox_FilePath.Clear();
        }


        private void AddAnswerButton_Click(object sender, EventArgs e)
        {
            if (_numberOfAnswers < 7)
            {
                AddAnswerTextBox(_numberOfAnswers + 1);
                AddAnswerButton.Location = new Point(658, 284 + _numberOfAnswers * 57);
                Debug.WriteLine(_numberOfAnswers);
                if (_numberOfAnswers == 7)
                {
                    AddAnswerButton.Dispose(); // Remove the button from the form
                }
            }
        }

        private void SaveFile(string source, string destination)
        {
            try
            {
                File.Copy(source, destination, true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private int? getDifficultyfromComboBox()
        {
            if (comboBox1.SelectedItem != null)
            {
                string? key = comboBox1.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(key) && _DifficultChoices.TryGetValue(key, out int value))
                {
                    Debug.WriteLine(value);
                    return value;
                }
                else
                {
                    Debug.WriteLine($"Key '{key}' not found in _DifficultChoices.");
                    return null; // or handle the case when the key is not found
                }
            }
            else
            {
                Debug.WriteLine("No difficulty selected.");
                return null; // or handle the case when no item is selected
            }
        }

        private void button_CompeteQuestionClick(object sender, EventArgs e)
        {
            Question question = new Question();

            List<string>? result = TestQuestionFilled();
            if (result != null && result.Count > 0)
            {
                string errorMessage = string.Join(Environment.NewLine, result);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (textBox_FilePath.Text != string.Empty && File.Exists(textBox_FilePath.Text))
                {
                    string source = textBox_FilePath.Text;
                    string destination = AppDomain.CurrentDomain.BaseDirectory;
                    destination = destination + "Resources\\Images\\" + textBox_FilePath.Text.Split('\\').Last();
                    SaveFile(source, destination);
                    question.QuestionPictureName = textBox_FilePath.Text.Split('\\').Last();
                    question.QuestionPictureDescription = textBox_PictureDescription.Text;
                }
            }
            question.QuestionText = textBox_MainQuestionText.Text;
            if(!textBox_Title.Text.IsNullOrEmpty())
            {
                question.QuestionTitle = textBox_Title.Text;
            }
            question.QuestionLink = textBox_LinkAddress.Text;
            question.QuestionCathegories = textBox1.Text.Split(',').ToList();
            for (int i = 0; i < question.QuestionCathegories.Count; i++)
            {
                question.QuestionCathegories[i] = question.QuestionCathegories[i].ToLower();
            }

            string res = comboBox1.SelectedItem?.ToString() ?? 
                throw new NullReferenceException("difficulty choice does not have a correct value");
            question.QuestionDifficulty = (_DifficultChoices[res]);

            question.Answers = new List<string>();
            for (int i = 1; i <= _numberOfAnswers; i++)
            {
                question.Answers.Add(_AnswerBoxes["AnswerTextBox" + i.ToString()].Text);
                if (_AnswerCheckBoxes["AnswerCheckBox" + i.ToString()].Checked == true)
                {
                    question.CorrentAnswer = i - 1;
                }
            }
            
            dbOperator.CreateNewQuestion(question);
            Debug.WriteLine("Question created successfully.");
        }
    }
}
