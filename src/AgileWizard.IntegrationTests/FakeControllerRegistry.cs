using AgileWizard.Data;
using AgileWizard.Domain.Services;
using AgileWizard.Domain.Users;
using AgileWizard.Website.Mapper;
using StructureMap.Configuration.DSL;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.IntegrationTests
{
    public class FakeControllerRegistry : Registry
    {
        public FakeControllerRegistry()
        {
            For<IFormsAuthenticationService>().Use<FakeFormsAuthenticationService>();
            For<ISessionStateRepository>().Use<FakeSessoinStateRepository>().SetProperty(x=>x.CurrentUser = User.DefaultUser());
            For<IResourceMapper>().Use<ResourceMapper>();
        }

        public class FakeFormsAuthenticationService : IFormsAuthenticationService
        {
            #region IFormsAuthenticationService Members

            public void SignIn(string userName)
            {

            }

            public void SignOut()
            {

            }

            #endregion
        }
    }
}
