using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using AgileWizard.Website.Models;

namespace AgileWizard.IntegrationTests
{
    public class FakeControllerRegistry : Registry
    {
        public FakeControllerRegistry()
        {
            For<IFormsAuthenticationService>().Use<FakeFormsAuthenticationService>();
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
