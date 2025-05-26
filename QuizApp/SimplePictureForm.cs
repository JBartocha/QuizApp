using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                    string fullpath = AppDomain.CurrentDomain.BaseDirectory;
                    var dirInfo = new DirectoryInfo(fullpath);

                    //Move up three levels: bin -> Debug -> net9.0 -> ProjectRoot
                    for (int i = 0; i < 4; i++)
                    {
                        if (dirInfo.Parent != null)
                            dirInfo = dirInfo.Parent;
                        else
                            break;
                    }
                    fullpath = dirInfo.FullName + "\\Resources\\Images\\" + picturePath;
                    Debug.WriteLine($"Full path to image42: {fullpath}");
                    PictureBox pictureBox = new PictureBox
                    {

                        Image = Image.FromFile(fullpath),
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
