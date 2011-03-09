using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Models;
using StructureMap.Configuration.DSL;

namespace AgileWizard.Website
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();
            For<ISessionStateRepository>().Use<SessionStateRepository>();
        }
    }
}