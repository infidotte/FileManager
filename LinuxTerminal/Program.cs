using System;
using System.Diagnostics;
using System.Management;

namespace LinuxTerminal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Для информации о доступных коммандах введите: help");
                string command = Console.ReadLine();
                string[] arguments = command.Split(' ');
                string sessionname;
                switch (arguments[0])
                {
                    case "ps":
                        if (arguments[1].Equals("-e") && arguments.Length == 2)
                        {
                            foreach (var VARIABLE in Process.GetProcesses())
                            {
                                Console.WriteLine(VARIABLE.Id + " " + VARIABLE.TotalProcessorTime + " " +
                                                  VARIABLE.ProcessName);
                            }
                        }
                        else if (arguments[1].Equals("p"))
                        {
                            int pid = Int32.Parse(arguments[2]);
                            Process process = Process.GetProcessById(pid);

                            if (process.SessionId == 0)
                            {
                                sessionname = "Services";
                            }
                            else
                            {
                                sessionname = "Console";
                            }

                            Console.WriteLine(process.ProcessName + " " + process.Id + " " + process.SessionId +
                                              " " + sessionname +
                                              " " + process.WorkingSet64 / 1024 + " KB");
                        }
                        else if (arguments[1].Equals("-C"))
                        {
                            string name = arguments[2];
                            foreach (var proc in Process.GetProcessesByName(name))
                            {
                                if (proc.SessionId == 0)
                                {
                                    sessionname = "Services";
                                }
                                else
                                {
                                    sessionname = "Console";
                                }

                                Console.WriteLine(proc.ProcessName + " " + proc.Id + " " + proc.SessionId + " " +
                                                  sessionname + " " +
                                                  proc.WorkingSet64 / 1024 + " KB");
                            }
                        }
                        else if (arguments[1].Equals("-e") && arguments.Length == 5)
                        {
                            string user = arguments[4];
                            foreach (var VARIABLE in Process.GetProcesses())
                            {
                                if (VARIABLE.SessionId == 0)
                                {
                                    sessionname = "Services";
                                }
                                else
                                {
                                    sessionname = "Console";
                                }

                                if (user.Equals(GetProcessOwner(VARIABLE.Id)))
                                    Console.WriteLine(GetProcessOwner(VARIABLE.Id) + " " + VARIABLE.ProcessName +
                                                      " " + VARIABLE.Id + " " + VARIABLE.SessionId +
                                                      " " +
                                                      sessionname + " " + VARIABLE.WorkingSet64 / 1024 + " KB");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong command!");
                        }

                        break;
                    case "killall":
                        string klname = arguments[1];
                        try
                        {
                            foreach (var VARIABLE in Process.GetProcessesByName(klname))
                            {
                                VARIABLE.Kill();
                                Console.WriteLine("Процессы успешно приостановлены");
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                        break;
                    case "kill":
                        if (arguments[1].Equals("-9"))
                        {
                            int kid = Int32.Parse(arguments[2]);
                            try
                            {
                                Process.GetProcessById(kid).Kill();
                                Console.WriteLine("Процесс успешно приостановлен");
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong command!");
                        }

                        break;
                    case "mount":
                        if (arguments.Length == 4)
                        {
                            if (arguments[1].Equals("") && arguments[2].Equals(""))
                            {
                                switch (arguments[3])
                                {
                                    case "dm":
                                        DesktopMonitor();
                                        break;
                                    case "sd":
                                        SoundDevice();
                                        break;
                                    case "k":
                                        Keyboard();
                                        break;
                                    case "pd":
                                        PointingDevices();
                                        break;
                                    default:
                                        Console.WriteLine("Wrong command!");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong command!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong command!");
                        }

                        break;
                    case "help":
                        Console.WriteLine(
                            "Все доступные комманды: \n" +
                            "ps -e - выводит все процессы\n" +
                            "ps -e | grep ? - выводит все процессы выбранного пользователя\n" +
                            "ps p ? - выводит процесс с указанным ID \n" +
                            "ps -C ? - выводит все процессы с указанным именем \n" +
                            "killall ? - приостанавлиет все процессы с указанным именем\n" +
                            "kill -9 ? - приостанавливает процесс с указанным ID\n" +
                            "mount | grep dm - выводит информацию о подключенных мониторах\n" +
                            "mount | grep sd - выводит информацию о подключенных аудио-девайсах\n" +
                            "mount | grep k - выводит информацию о подключенных клавиатурах\n" +
                            "mount | grep pd- выводит информацию о подключенных USB девайсах"
                        );
                        break;
                    default:
                        Console.WriteLine("Wrong command!");
                        break;
                }
            }
        }

        public static string GetProcessOwner(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] {string.Empty, string.Empty};
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return DOMAIN\user
                    return argList[0];
                }
            }

            return "NO OWNER";
        }

        static void DesktopMonitor()
        {
            ManagementObjectSearcher win32Monitor = new ManagementObjectSearcher("select * from Win32_DesktopMonitor");
            foreach (ManagementObject obj in win32Monitor.Get())
            {
                Console.WriteLine(obj.ToString());
            }
        }

        static void SoundDevice()
        {
            ManagementObjectSearcher Win32_SoundDevice =
                new ManagementObjectSearcher("select * from Win32_SoundDevice");
            foreach (ManagementObject obj in Win32_SoundDevice.Get())
            {
                Console.WriteLine(obj.ToString());
            }
        }

        static void Keyboard()
        {
            ManagementObjectSearcher Win32_Keyboard = new ManagementObjectSearcher("select * from Win32_Keyboard");
            foreach (ManagementObject obj in Win32_Keyboard.Get())
            {
                Console.WriteLine(obj.ToString());
            }
        }

        static void PointingDevices()
        {
            ManagementObjectSearcher Win32_PointingDevice =
                new ManagementObjectSearcher("select * from Win32_PointingDevice");
            foreach (ManagementObject obj in Win32_PointingDevice.Get())
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}