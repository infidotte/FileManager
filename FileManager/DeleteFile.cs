using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    
    public partial class DeleteFile : Form
    {
        private string localpath;
        private string trashpath;
        public DeleteFile(Point point, string localpath, string trashpath)
        {
            InitializeComponent();
            this.Location = point;
            this.localpath = localpath;
            this.trashpath = trashpath;
        }

        private void fulldelete_Click(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(localpath);
            if ((info.Attributes & FileAttributes.Directory) != 0)
            {
                info.Delete(true);
            }
            else
            {
                File.Delete(localpath);
            }
            
            Close();
        }

        private void totrash_Click(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(localpath);
            try
            {
                info.MoveTo(trashpath + "\\" + info.Name);
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            Close();
        }
        
    }
}