using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Entities;

namespace AgileWizard.IntegrationTests
{
    public class FakeControllerRegistry : Registry
    {
        public FakeControllerRegistry()
        {
            For<IFormsAuthenticationService>().Use<FakeFormsAuthenticationService>();
            For<ISessionStateRepository>().Use<FakeSessoinStateRepository>();

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

        public class FakeSessoinStateRepository : ISessionStateRepository
        {
            private Dictionary<string, object> _dic = new Dictionary<string, object>();
            public User CurrentUser
            {
                get { return new User { UserName = "agilewizard" }; }
                set { }
            }

            public object this[string name]
            {
                get
                {
                    return _dic[name];
                }
                set
                {
                    _dic[name] = value;
                }
            }
        }
    }
}
