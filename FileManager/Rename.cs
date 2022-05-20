using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Rename : Form
    {
        private DirectoryInfo info;
        public Rename(Point point ,DirectoryInfo info)
        {
            this.info = info;
            Location = point;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ((info.Attributes & FileAttributes.Directory) != 0)
            {
                
                Directory.Move(info.FullName, info.Parent.FullName + "\\" + textBox1.Text);
            }
            else
            {
                string ext = info.Name.Split('.')[1];
                File.Move(info.FullName, info.Parent.FullName + "\\" + textBox1.Text + "." + ext);
            }
            Close();
        }
    }
}