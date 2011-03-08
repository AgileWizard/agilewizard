using System.Web.Mvc;

namespace AgileWizard.Website.Tests.PageObject
{
    public class ListPage : IndexListPage
    {
        public ListPage(ActionResult actionResult) 
            : base(actionResult)
        {
            _viewName = "ResourceList";
        }
    }
}
