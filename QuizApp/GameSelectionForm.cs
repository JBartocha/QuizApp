using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class GameSelectionForm : Form
    {
        private readonly static Dictionary<string, int> _DifficultChoices = new Dictionary<string, int>
            {
                { "Lehká", 3 },
                { "Střední", 5 },
                { "Těžká", 7 },
            }; 

        GameSelectionDatabaseOperator _GDO = new();
        Dictionary<string, int> _Cathegories = new();

        public GameSelectionForm()
        {
            _Cathegories = _GDO.Get_All_Cathegories_FromDB();
            int index = 0;
            int MaxIndexperColumn = 5; // Maximum number of items per column

            foreach (var cathegory in _Cathegories)
            {
                CheckBox checkbox = new();
                checkbox.Location = new Point(280 + (200 * (index / MaxIndexperColumn)), 
                    20 + 50 * (index % MaxIndexperColumn));
                checkbox.AutoSize = true; // Adjusts size to fit text
                checkbox.Text = cathegory.Key; // Set the text to the category name
                checkbox.Name = "checkbox_" + index; // Set a unique name for the checkbox
                this.Controls.Add(checkbox); // 'this' refers to the current Form
                index++;
            }
            InitializeComponent();
            SetComponents();
        }

        private void SetComponents()
        {
            foreach (var choice in _DifficultChoices)
            {
                comboBox1.Items.Add(choice.Key);
            }
            comboBox1.SelectedIndex = 0; // Set default selection to the first item
            comboBox_NumberOfQuestions.SelectedIndex = 0; // Initialize the number of questions
        }

        private void button_BeginGame_Click(object sender, EventArgs e)
        {
            List<int> CathegoryIDs = new();


            string pom = comboBox1.SelectedItem!.ToString()!; // Error never happend
            int difficulty = _DifficultChoices[pom];
            int numberOfQuestions = int.Parse(comboBox_NumberOfQuestions.SelectedItem!.ToString()!); // Error never happend

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Name.StartsWith("checkbox_"))
                {
                    if (checkBox.Checked)
                    {
                        CathegoryIDs.Add(_Cathegories[checkBox.Text]);
                    }
                }
            }

            using (MainGameForm mainGameForm = new(CathegoryIDs, difficulty, numberOfQuestions))
            {
                if(CathegoryIDs.Count <= 2)
                {
                    MessageBox.Show("Vyberte alespoň tři kategorie pro hru.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; // Exit the method if no categories are selected
                }
                this.Hide(); // Hide the GameSelectionForm
                mainGameForm.ShowDialog(); // Show the MainGameForm as a dialog
                this.Show(); // Show the GameSelectionForm again after the game is finished
            }
            this.Close(); // Close the GameSelectionForm after the game is finished
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the GameSelectionForm and returns to the previous form
        }
    }
}
