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
    }
}
