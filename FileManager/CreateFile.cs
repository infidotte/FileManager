using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FileManager
{
    public partial class CreateFile : Form
    {
        private string localpath;

        public CreateFile(Point point, string localpath)
        {
            InitializeComponent();
            this.Location = point;
            this.localpath = localpath;
        }

        private void create_Click(object sender, EventArgs e)
        {
            string filename = name.Text;
            string fileextension = extension.Text;
            if (fileextension.Equals(""))
            {
                
                try
                {
                    Directory.CreateDirectory(localpath + "\\" + filename);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                try
                {
                    File.Create(localpath + "\\" + filename + "." + fileextension).Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            Close();
        }
    }
}