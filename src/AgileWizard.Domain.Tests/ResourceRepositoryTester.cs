using System.Linq;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Domain.Repositories;
using Xunit;

namespace AgileWizard.Domain.Tests
{
    public class ResourceRepositoryTester : RepositoryTesterBase
    {
        private readonly ResourceRepository _resourceRepositorySUT;

        public ResourceRepositoryTester()
        {
            _resourceRepositorySUT = new ResourceRepository(_documentSession);
        }

        [Fact]
        public void add_resource()
        {
            string title = "title";
            string content = "content";
            
            _resourceRepositorySUT.Add(title, content);

            ResourceHasBeenSaved(title);
        }
        
        private Resource GetResourceByTitle(string title)
        {
            var resources = _documentSession.Query<Resource>(typeof(ResourceIndexByTitle).Name).Customize(x => x.WaitForNonStaleResults());

            var _resultResources = from x in resources
                                   where x.Title == title
                                   select x;
            return _resultResources.First();
        }

        private void ResourceHasBeenSaved(string title)
        {
            var expectedResource = GetResourceByTitle(title);

            Assert.NotNull(expectedResource);
            Assert.Equal(expectedResource.Title, title);
        }
    }

}
