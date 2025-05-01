using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APEX.Configuration.Configurations;
using Microsoft.Extensions.Configuration;

namespace APEX.Configuration.Settings
{
    public static class ConfigurationManager
    {
        private static IConfiguration _configuration;

        static ConfigurationManager()
        {
                //var builder = new ConfigurationBuilder()
                //    .SetBasePath(Directory.GetCurrentDirectory())
                //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //    .AddEnvironmentVariables();

                //_configuration = builder.Build();
        }

        public static DatabaseConfig DatabaseConfig => GetSection<DatabaseConfig>("Database");
        public static ApplicationSettings ApplicationSettings => GetSection<ApplicationSettings>("Application");

        private static T GetSection<T>(string sectionName) where T : new()
        {
            var section = new T();
        //    _configuration.GetSection(sectionName).Bind(section);
            return section;
        }
    }
}
