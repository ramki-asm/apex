using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class TcpIpConnectionSettings
    {
        public string IpAddress { get; set; } = "192.168.1.1";
        public int Port { get; set; } = 502;
        public int Timeout { get; set; } = 5000;
    }
}
