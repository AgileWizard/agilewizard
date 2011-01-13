using System;
using System.Web.Mvc;
using Xunit;

namespace AgileWizard.IntegrationTests.PageObject
{
    public class Home : IntegrationTestBase
    {
        private const string _controllerName = "home";
        private const string _actionName = "index";

        public Home()
            : base(_controllerName, _actionName)
        {
        }
    }
}
