using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Daily_Task_Tracker_WFA
{
    public partial class DailyTasktracker : Form
    {
        readonly List<Process> listOfRunningProcess = new List<Process>();
        readonly ConcurrentDictionary<IntPtr, ProcessDetails> ListOfProcessTimes = new ConcurrentDictionary<IntPtr, ProcessDetails>();
        private static readonly object lockObject = new object();

        public DailyTasktracker()
        {
            InitializeComponent();
            Thread t = new Thread(() => GetProcess());
            t.Start();
        }

        private void DailyTasktracker_Load(object sender, EventArgs e)
        {
            UsrLbl.Text = Environment.UserName;
        }
        public void GetProcess()
        {
            try
            {
                Process[] getProcess;
                while (true)
                {
                    Thread.Sleep(1000);
                    getProcess = Process.GetProcesses();
                    foreach (var item in getProcess)
                    {
                        if (item.MainWindowTitle != "")
                        {
                            if (listOfRunningProcess.Count == 0)
                            {
                                listOfRunningProcess.Add(item);
                            }
                            else if (!listOfRunningProcess.Any(h => h.MainWindowHandle == item.MainWindowHandle))
                            {
                                listOfRunningProcess.Add(item);
                                Thread newThread = new Thread(() => CalculateTimeForProcesses(item));
                                newThread.Start();
                                Thread new1Thread = new Thread(() => GetTimeForEveryProcess(item));
                                new1Thread.Start();

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddDataToDataBase(string applicationName, string startTime, string exitTime, string TotalProcessTime, string UserInteractionTime)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DailyTaskDBConnectionString"].ToString());
                string insertString = "insert into [DailyTaskTracker]([ApplicationName],[StartTime],[ExitTime],[TotalProcessTime],[UserInteractionTime]) values ('" + applicationName + "','" + startTime + "','" + exitTime + "','" + TotalProcessTime + "','" + UserInteractionTime + "')";
                SqlCommand cmd = new SqlCommand(insertString, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CalculateTimeForProcesses(Process p)
        {
            p.EnableRaisingEvents = true;
            string applicationName = p.MainModule.FileVersionInfo.FileDescription;
            DateTime startTime = p.StartTime;
            string UserInteractionTime = null;
            p.WaitForExit();
            for (int i = 0; i < ListOfProcessTimes.Count; i++)
            {
                if (p.MainWindowHandle == ListOfProcessTimes.ElementAt(i).Key)
                {
                    UserInteractionTime = ListOfProcessTimes.ElementAt(i).Value.userInteractionTime.ToString();
                    ListOfProcessTimes.TryRemove(ListOfProcessTimes.ElementAt(i).Key, out _);
                    break;
                }
            }
            DateTime exitTime = p.ExitTime;
            string TotalProcessTime = exitTime.Subtract(startTime).ToString();

            AddDataToDataBase(applicationName, startTime.ToString(), exitTime.ToString(), TotalProcessTime, UserInteractionTime);
        }

        private void ListBtn_Click(object sender, EventArgs e)
        {
            ShowDetails formshow = new ShowDetails();
            formshow.Show();
        }

        private void DailyTasktracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        public void GetTimeForEveryProcess(Process p)
        {
            Stopwatch stopwatch = new Stopwatch();

            LASTINPUTINFO info = new LASTINPUTINFO();
            info.size = Marshal.SizeOf(info);
            info.dwtime = 0;
            int lastInput = 0;
            GetLastInputInfo(ref info);
            while (true)
            {
                GetLastInputInfo(ref info);
                Thread.Sleep(100);
                IntPtr thishandle = GetForegroundWindow();

                if (!ListOfProcessTimes.ContainsKey(p.MainWindowHandle))
                {
                    ProcessDetails process = new ProcessDetails { handle = p.MainWindowHandle, userInteractionTime = 0 };
                    ListOfProcessTimes.TryAdd(p.MainWindowHandle, process);
                }
                else
                {
                    if (thishandle == p.MainWindowHandle)
                    {
                        if (ListOfProcessTimes.TryGetValue(p.MainWindowHandle, out ProcessDetails item))
                        {
                            if (lastInput != info.dwtime)
                            {
                                double elapsedMiliseconds = Math.Abs(stopwatch.Elapsed.TotalMilliseconds);
                                long interactionTimeInMiliseconds = Math.Abs(info.dwtime - lastInput);
                                UpdateProcessTime(item.handle, interactionTimeInMiliseconds - elapsedMiliseconds);
                                stopwatch.Reset();
                                stopwatch.Stop();
                            }
                            else
                            {
                                if (!stopwatch.IsRunning)
                                {
                                    stopwatch.Start();
                                }
                            }
                        }
                    }
                }
                lastInput = info.dwtime;
            }
        }
        private void UpdateProcessTime(IntPtr handle, double time)
        {
            lock (lockObject)
            {
                if (ListOfProcessTimes.TryGetValue(handle, out ProcessDetails item))
                {
                    item.userInteractionTime += time;
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("User32.dll")]
        private static extern int GetLastInputInfo(ref LASTINPUTINFO plii);

        public struct LASTINPUTINFO
        {
            public int size;
            public int dwtime;
        }
    }
}

