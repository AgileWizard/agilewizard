using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileWizard.Domain.Repositories
{
    public interface IConfigurationRepository
    {
        string GetValue(string key);
    }
}
