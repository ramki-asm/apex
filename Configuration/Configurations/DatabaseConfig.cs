using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEX.Configuration.Configurations
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
        public int Timeout { get; set; } = 30;
        public bool EnableLogging { get; set; } = true;
        public bool EnableSensitiveDataLogging { get; set; } = false;
    }
}
