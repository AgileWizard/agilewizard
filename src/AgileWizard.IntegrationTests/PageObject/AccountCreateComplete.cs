using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Xunit;

namespace AgileWizard.IntegrationTests.PageObject
{
    public class AccountCreateComplete: IntegrationTestBase
    {
        private const string _controllerName = "account";
        private const string _actionName = "createComplete";

        public AccountCreateComplete()
            : base(_controllerName, _actionName)
        {
            
        }
    }
}
