using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configuration = new();
                configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/CarBook.WebApi"));
                configuration.AddJsonFile("appsettings.json");
                return configuration.GetConnectionString("SqlServer");
            }
        }
    }
}
