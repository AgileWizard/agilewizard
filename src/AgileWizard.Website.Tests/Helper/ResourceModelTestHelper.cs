using AgileWizard.Domain.Models;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Tests.Helper
{
    public class ResourceModelTestHelper
    {
        public static ResourceDetailViewModel BuildDefaultResourceDetailViewModel()
        {
            return new ResourceDetailViewModel(Resource.DefaultResource());
        }
    }
}
