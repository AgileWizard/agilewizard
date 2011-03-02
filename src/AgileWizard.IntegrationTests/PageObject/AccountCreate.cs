using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Xunit;

namespace AgileWizard.IntegrationTests.PageObject
{
    public class AccountCreate: IntegrationTestBase
    {
        private const string _controllerName = "account";
        private const string _actionName = "create";

        public AccountCreate()
            : base(_controllerName, _actionName)
        {
            
        }

        public void AssertEmptyData<T>(ActionResult actionResult)
        {
            var viewResult = actionResult as ViewResult;
            var model = viewResult.ViewData["model"];

            Assert.Null(model);
        }
    }
}
