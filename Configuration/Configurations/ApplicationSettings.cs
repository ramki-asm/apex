using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APEX.Common.Enums;

namespace APEX.Configuration.Configurations
{
    public class ApplicationSettings
    {
        public string ApplicationName { get; set; } = "APEX";
        public string Version { get; set; } = "1.0.0";
        public string DefaultCulture { get; set; } = "en-US";
        public int SessionTimeout { get; set; } = 30;
        public ApplicationTheme DefaultTheme { get; set; } = ApplicationTheme.Light;
    }
}
