using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Task_Tracker_WFA
{
    public class ProcessDetails
    {
        public IntPtr handle;
        public double userInteractionTime;
        public int lastInputTime { get; set; }
    }
}
