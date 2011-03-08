using AgileWizard.Website.Tests.PageObject;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenListPaging : ListResource
    {
        public WhenListPaging()
        {
            const int currentPage = 0;

            _actionResult = resourceControllerSUT.ResourceList(currentPage);

            IndexListPage = new ListPage(_actionResult);
        }
    }
}
