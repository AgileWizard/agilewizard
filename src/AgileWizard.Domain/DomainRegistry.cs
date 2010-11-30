using StructureMap.Configuration.DSL;

namespace AgileWizard.Domain
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            For<IUserRepository>().Use<UserRepository>();
            For<IResourceRepository>().Use<ResourceRepository>();
            For<IUerAuthenticationService>().Use<UerAuthenticationService>();
        }
    }
}
