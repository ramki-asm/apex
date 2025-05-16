using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class MachineLog
    {
        public string ProductName { get; set; }
        public ObservableCollection<string> LogEntries { get; set; }
        public int TotalCount { get; set; }
        public int OkCount { get; set; }
        public int TossingCount { get; set; }
        public TimeSpan CycleTime { get; set; }
        public TimeSpan LeadTime { get; set; }
    }
}
