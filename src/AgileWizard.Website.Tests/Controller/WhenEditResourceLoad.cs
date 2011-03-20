using AgileWizard.Domain.Models;
using AgileWizard.Website.Tests.PageObject;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenEditResourceLoad : OneResourceLoadBase
    {
        private EditPage _editPage;
        public WhenEditResourceLoad()
        {
            _actionResult = _resourceControllerSUT.Edit(Resource.ID);

            _editPage = new EditPage(_actionResult);
        }

        [Fact]
        public void ResourceEdit_ShouldBeLoaded()
        {
            _editPage.Assert_Load();
        }
    }
}
