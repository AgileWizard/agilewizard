namespace AgileWizard.IntegrationTests.PageObject
{
    public class ResourceEdit: IntegrationTestBase
    {
        private const string _controllerName = "resource";
        private const string _actionName = "edit";

        public ResourceEdit()
            : base(_controllerName, _actionName)
        {
        }
    }
}
