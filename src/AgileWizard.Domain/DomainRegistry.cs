using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using System.IO;

namespace AgileWizard.Domain
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            For<IUserRepository>().Use<UserRepository>();
        }
    }
}
