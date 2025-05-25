using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class SimplePictureForm : Form
    {
        public SimplePictureForm(string? picturePath)
        {
            InitializeComponent();

            if (picturePath != null)
            {
                try
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = Image.FromFile(picturePath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Dock = DockStyle.Fill
                    };
                    this.Controls.Add(pictureBox);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No picture path provided.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
