using AgileWizard.Website.Tests.PageObject;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenIndexLoad : ListResource
    {
        public WhenIndexLoad()
        {
            _actionResult = resourceControllerSUT.Index();

            IndexListPage = new IndexListPage(_actionResult);
        }
    }
}
