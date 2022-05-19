using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FileManager
{
    public partial class CreateFile : Form
    {
        private Singleton singleton = Program.singleton;
        public CreateFile()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            string filename = name.Text;
            string fileextension = extension.Text;
            lock (singleton)
            {
                if (fileextension.Equals(""))
                {
                    try
                    {
                        Directory.CreateDirectory(singleton.localpath + "\\" + filename);
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                else
                {
                    
                    try
                    {
                        File.Create(singleton.localpath + "\\" + filename + "." + fileextension);
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            Close();
        }
    }
}