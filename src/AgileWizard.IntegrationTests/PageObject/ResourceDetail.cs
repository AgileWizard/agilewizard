using System;
using System.Web.Mvc;

namespace AgileWizard.IntegrationTests.PageObject
{
    public class ResourceDetail:IntegrationTestBase
    {
        private const string _actionName = "details";
        private const string _controllerName = "resource";

        public ResourceDetail()
            : base(_controllerName, _actionName)
        {
        }

        public void AssertAction(RedirectToRouteResult actionResult, string id)
        {
            AssertAction(actionResult);
            ActionResultCompare(actionResult, "id", id);
        }
    }
}
