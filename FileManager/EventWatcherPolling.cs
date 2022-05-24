using System;
using System.IO;
using System.IO.Pipes;
using System.Management;
using System.Windows.Forms;

namespace FileManager
{
    public class EventWatcherPolling
    {
        private ManagementEventWatcher processStart =
            new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");

        private ManagementEventWatcher processStop = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
        private string logfile = "logfile.txt";

        public EventWatcherPolling()
        {
            processStart.EventArrived += new EventArrivedEventHandler(checkProcessStart);
            processStop.EventArrived += new EventArrivedEventHandler(checkProcessStop);
            processStart.Start();
            processStop.Start();
        }

        private void checkProcessStart(object sender, EventArrivedEventArgs e)
        {
            lock (logfile)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(logfile, true))
                    {
                        string message = getProcessUser(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)) + 
                                         " | " + e.NewEvent.Properties["ProcessName"].Value + " открыт в " +
                                         DateTime.Now + "\n";
                        writer.Write(message);
                        if (Program.singleton.locker)
                        {
                            pipeLineWriter(message);
                            using (StreamWriter streamWriter = new StreamWriter("chanals.txt", true))
                            {
                                streamWriter.Write(message);
                            }
                        }
                    }
                }
                catch (IOException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void checkProcessStop(object sender, EventArrivedEventArgs e)
        {
            lock (logfile)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(logfile, true))
                    {
                        string message = getProcessUser(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)) + 
                                         " | " + e.NewEvent.Properties["ProcessName"].Value + " закрыт в " +
                                         DateTime.Now + "\n";
                        writer.Write(message);
                        if (Program.singleton.locker)
                        {
                            pipeLineWriter(message);
                            using (StreamWriter streamWriter = new StreamWriter("chanals.txt", true))
                            {
                                streamWriter.Write(message);
                            }
                        }
                    }
                }
                catch (IOException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        public string getProcessUser(int idprocess)//Вывод пользователя процесса
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ProcessID = "
                                                                             + idprocess);
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject obj in collection)
            {
                string[] array = {"",""};
                if (Convert.ToInt32(obj.InvokeMethod("GetOwner", array)) == 0)
                {
                    return array[1] + "\\" + array[0];
                }
            }
            return "unknown";
        }
        private void pipeLineWriter(string message)
        {
            NamedPipeServerStream pipeLineServer = new NamedPipeServerStream("pipeLine", PipeDirection.Out);
            pipeLineServer.WaitForConnection();
            if (pipeLineServer.IsConnected)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(pipeLineServer))
                    {
                        writer.WriteLine(message);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }
    }
}