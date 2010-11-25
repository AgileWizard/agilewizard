using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using AgileWizard.Website.Models;

namespace AgileWizard.Website
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();
        }
    }
}