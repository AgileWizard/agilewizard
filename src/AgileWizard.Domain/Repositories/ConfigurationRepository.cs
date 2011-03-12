using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AgileWizard.Domain.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
