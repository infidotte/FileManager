using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Principal;

namespace WinTerminal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //get process by id ||||| tasklist /fi "PID eq ?"
            //                        
            //

            //linux
            //ps p process_id
            //ps -C command_name
            //ps -e
            //ps -e | grep name
            //killall name
            //kill -9 id


            while (true)
            {
                Console.WriteLine("Для информации о доступных коммандах введите: help");
                string command = Console.ReadLine();
                string[] arguments = command.Split(' ');
                string sessionname;
                switch (arguments[0])
                {
                    case "tasklist":
                        if (arguments.Length == 1)
                        {
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

                                //cmd
                                Console.WriteLine(VARIABLE.ProcessName + " " + VARIABLE.Id + " " + VARIABLE.SessionId +
                                                  " " +
                                                  sessionname + " " + VARIABLE.WorkingSet64 / 1024 + " KB");
                            }
                        }
                        else
                        {
                            //tasklist /fi "USERNAME eq name"

                            if (arguments[2].Equals("\"USERNAME") && arguments[3].Equals("eq"))
                            {
                                string user = arguments[4].Remove(arguments[4].Length - 1, 1);
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
                            //tasklist /fi "PID eq ?"

                            else if (arguments[2].Equals("\"PID") && arguments[3].Equals("eq"))
                            {
                                int pid = Int32.Parse(arguments[4].Remove(arguments[4].Length - 1, 1));
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
                            //tasklist /fi "IMAGENAME eq ?"

                            else if (arguments[2].Equals("\"IMAGENAME") && arguments[3].Equals("eq"))
                            {
                                string name = arguments[4].Remove(arguments[4].Length - 1, 1);
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
                            //tasklist /fi "MEMUSAGE gt ?"
                            else if (arguments[2].Equals("\"MEMUSAGE") && arguments[3].Equals("gt"))
                            {
                                int size = Int32.Parse(arguments[4].Remove(arguments[4].Length - 1, 1));
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

                                    if (VARIABLE.WorkingSet64 / 1024 >= size)
                                        Console.WriteLine(VARIABLE.ProcessName + " " + VARIABLE.Id + " " +
                                                          VARIABLE.SessionId + " " +
                                                          sessionname + " " + VARIABLE.WorkingSet64 / 1024 + " KB");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong command!");
                            }
                        }

                        break;
                    case "taskkill":
                        //taskkill /im name
                        if (arguments[1].Equals("/im"))
                        {
                            string klname = arguments[2];
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
                        }
                        //taskkill /pid ?
                        else if (arguments[1].Equals("/pid"))
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
                    case "dm":
                        switch (arguments[1])
                        {
                            case "DesktopMonitor":
                                DesktopMonitor();
                                break;
                            case "SoundDevice":
                                SoundDevice();
                                break;
                            case "Keyboard":
                                Keyboard();
                                break;
                            case "PointingDevice":
                                PointingDevices();
                                break;
                            default:
                                Console.WriteLine("Wrong command!");
                                break;
                        }

                        break;
                    case "help":
                        Console.WriteLine(
                            "Все доступные комманды: \n" +
                            "tasklist - выводит все процессы\n" +
                            "tasklist /fi \"USERNAME\" eq ?\" - выводит все процессы выбранного пользователя\n" +
                            "tasklist /fi \"PID eq ?\" - выводит процесс с указанным ID \n" +
                            "tasklist /fi \"IMAGENAME eq ?\" - выводит все процессы с указанным именем \n" +
                            "tasklist /fi \"MEMUSAGE gt ?\" - выводит все процессы, имеющие > или = указанной памяти в КБ\n" +
                            "taskkill /im ? - приостанавлиет все процессы с указанным именем\n" +
                            "taskkill /pid ? - приостанавливает процесс с указанным ID\n" +
                            "dm DesktopMonitor - выводит информацию о подключенных мониторах\n" +
                            "dm SoundDevice - выводит информацию о подключенных аудио-девайсах\n" +
                            "dm Keyboard - выводит информацию о подключенных клавиатурах\n" +
                            "dm PointingDevice - выводит информацию о подключенных USB девайсах"
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