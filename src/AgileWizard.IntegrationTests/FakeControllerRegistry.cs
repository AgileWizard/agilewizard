using AgileWizard.Data;
using AgileWizard.Domain.Services;
using AgileWizard.Domain.Users;
using StructureMap.Configuration.DSL;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.IntegrationTests
{
    public class FakeControllerRegistry : Registry
    {
        public FakeControllerRegistry()
        {
            For<IFormsAuthenticationService>().Use<FakeFormsAuthenticationService>();
            For<ISessionStateRepository>().Use<FakeSessoinStateRepository>().SetProperty(x=>x.CurrentUser = User.DefaultUser());

        }

        public class FakeFormsAuthenticationService : IFormsAuthenticationService
        {
            #region IFormsAuthenticationService Members

            public void SignIn(string userName, bool createPersistentCookie)
            {

            }

            public void SignOut()
            {

            }

            #endregion
        }
    }
}
