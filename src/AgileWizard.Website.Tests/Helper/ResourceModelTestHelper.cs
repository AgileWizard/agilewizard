using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Tests.Helper
{
    public class ResourceModelTestHelper
    {
        public static ResourceDetailViewModel BuildDefaultResourceDetailViewModel()
        {
            return new ResourceDetailViewModel()
                       {
                           Id = Resource.DefaultResource().Id,
                           Title = Resource.DefaultResource().Title,
                           Content = Resource.DefaultResource().Content,
                           Author = Resource.DefaultResource().Author,
                           ReferenceUrl = Resource.DefaultResource().ReferenceUrl,
                           Tags = "TDD,Shanghai"
                       };
        }
    }
}
