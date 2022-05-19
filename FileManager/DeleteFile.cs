using System;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    
    public partial class DeleteFile : Form
    {
        private Singleton singleton = Program.singleton;
        public DeleteFile()
        {
            InitializeComponent();
        }

        private void fulldelete_Click(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(singleton.localpath);
            if ((info.Attributes & FileAttributes.Directory) == 0)
            {
                
                File.Delete(singleton.localpath);
            }
            else
            {
                Directory.Delete(singleton.localpath, true);
            }
        }

        private void totrash_Click(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(singleton.localpath);
            if ((info.Attributes & FileAttributes.Directory) == 0)
            {
                
                File.Move(singleton.localpath, singleton.gettrashpath());
            }
            else
            {
                Directory.Move(singleton.localpath, singleton.gettrashpath());
            }
        }
        
    }
}