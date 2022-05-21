using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loging
{
    public partial class Form1 : Form
    {
        NamedPipeClientStream pipeClientStream;

        public Form1()
        {
            InitializeComponent();
            Thread thread = new Thread(pipelineThread);
            thread.Start();
        }

        public void disconnect(object sender, EventArgs e)
        {
            pipeClientStream.Dispose();
            pipeClientStream.Close();
        }

        public void pipelineThread()
        {
            while (true)
            {
                string message;
                pipeClientStream = new NamedPipeClientStream(".", "pipeLine", PipeDirection.In);

                pipeClientStream.Connect();

                using (StreamReader reader = new StreamReader(pipeClientStream))
                {
                    message = reader.ReadLine();
                    if (message != null && !message.Equals("") && !message.Equals("Close"))
                    {
                        richTextBox1.Text += message + "\n";
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Close();
        }
    }
}