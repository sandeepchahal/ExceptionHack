using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_Task_Tracker_WFA
{
    public partial class DailyTasktracker : Form
    {
        List<Process> listOfRunningProcess = new List<Process>();
        List<ProcessDetails> ListOfProcessTimes = new List<ProcessDetails>();
        public DailyTasktracker()
        {
            InitializeComponent();
            Thread t = new Thread(()=>GetProcess());
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
                    getProcess= Process.GetProcesses();
                    foreach (var item in getProcess)
                    {
                        if(item.MainWindowTitle!="")
                        {
                            if(listOfRunningProcess.Count==0)
                            {
                                listOfRunningProcess.Add(item);
                            }
                            else if(!listOfRunningProcess.Any(h=>h.MainWindowHandle==item.MainWindowHandle))
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddDataToDataBase(string applicationName,string startTime,string exitTime,string TotalProcessTime,string UserInteractionTime)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DailyTaskDBConnectionString"].ToString());
                string insertString = "insert into [DailyTaskTracker]([ApplicationName],[StartTime],[ExitTime],[TotalProcessTime],[UserInteractionTime]) values ('" + applicationName + "','" + startTime + "','" + exitTime + "','" + TotalProcessTime + "','"+UserInteractionTime+"')";
                SqlCommand cmd = new SqlCommand(insertString,connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                
            }
            catch(Exception ex)
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
                if (p.MainWindowHandle ==ListOfProcessTimes[i].handle)
                {
                    UserInteractionTime= ListOfProcessTimes[i].userInteractionTime.ToString();
                    ListOfProcessTimes.RemoveAt(i);
                    break;
                }
            }
            DateTime exitTime = p.ExitTime;
            string TotalProcessTime = exitTime.Subtract(startTime).ToString();
            AddDataToDataBase(applicationName, startTime.ToString(), exitTime.ToString(), TotalProcessTime,UserInteractionTime);
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
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("User32.dll")]
        private static extern int GetLastInputInfo(ref LASTINPUTINFO plii);

        public struct LASTINPUTINFO
        {
            public int size;
            public int dwtime;
        }
        public void GetTimeForEveryProcess(Process p)
        {
            LASTINPUTINFO info = new LASTINPUTINFO();
            info.size = Marshal.SizeOf(info);
            info.dwtime = 0;
            int lastInput = 0;
            while(true)
            {
                Thread.Sleep(100);
                info.dwtime = GetLastInputInfo(ref info);
                IntPtr thishandle = GetForegroundWindow();
                
                if (ListOfProcessTimes.Count == 0)
                {
                    ProcessDetails process = new ProcessDetails { handle = p.MainWindowHandle, userInteractionTime = 0 };
                    ListOfProcessTimes.Add(process);
                }
                else if (ListOfProcessTimes.Count!=0)
                {
                    foreach (var item in ListOfProcessTimes)
                    {
                        if (item.handle == thishandle)
                        {
                            if (lastInput != info.dwtime)
                            {
                                MessageBox.Show((info.dwtime - lastInput).ToString());
                                item.userInteractionTime += info.dwtime - lastInput;
                                break;
                            
                            }
                        }
                    }
                }
                else
                {
                    ProcessDetails process = new ProcessDetails { handle = p.MainWindowHandle, userInteractionTime = 0 };
                    ListOfProcessTimes.Add(process);
                }
                
                lastInput = GetLastInputInfo(ref info);
            }
        }
    }
}
