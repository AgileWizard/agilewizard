using AgileWizard.Domain.Models;
using AgileWizard.Website.Tests.PageObject;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenResourceDetailLoad : OneResourceLoadBase
    {
        private readonly DetailPage _detailPage;
        public WhenResourceDetailLoad()
        {
            _actionResult = _resourceControllerSUT.Details(Resource.ID);

            _detailPage = new DetailPage(_actionResult);
        }

        [Fact]
        public void ResourceDetail_ShouldBeLoaded()
        {
            _detailPage.Assert_Load();
        }
    }
}
