using System;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    public partial class CreateLog : Form
    {
        private string logs;
        public CreateLog(string logs)
        {
            InitializeComponent();
            this.logs = logs;
        }

        private void save_Click(object sender, EventArgs e)
        {
            string name = logname.Text;
            if (!name.Equals(""))
            {
                try
                {
                    File.Copy( "logfile.txt", Path.Combine(logs, name+".txt"), true);
                    Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Неверное имя");
            }
               
            
        }
    }
}