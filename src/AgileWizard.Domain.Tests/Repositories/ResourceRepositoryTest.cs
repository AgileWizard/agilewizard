using System.Collections.Generic;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Domain.Repositories;
using Xunit;

namespace AgileWizard.Domain.Tests.Repositories
{
    public class ResourceRepositoryTest : RepositoryTestBase
    {
        private readonly ResourceRepository _resourceRepositorySUT;
        private int _resourceCountNextPage;
        private const int _totalCountOfResourceOfLessThanOnePage = 11;
        private const int _totalCountOfResourceOfThreePages = 41;

        public ResourceRepositoryTest()
        {
            _resourceRepositorySUT = new ResourceRepository(_session.Object);
        }

        #region Add Resource
        [Fact]
        public void add_resource()
        {
            //Arrange
            var resource = Resource.DefaultResource();

            //Act
            _resourceRepositorySUT.Add(resource);

            //Assert
            _session.Verify(r => r.Store(resource));
        }
        #endregion

        #region Get One Resource
        [Fact]
        public void can_get_one_resource_with_given_id()
        {
            //Arrange
            const string ID = "1";

            //Act
            _resourceRepositorySUT.GetResourceById(ID);

            //Assert
            _session.Verify(s => s.Load<Resource>(DocumentId(ID)));
        }
        #endregion

        #region Resource List Paging Ordering
        [Fact]
        public void when_less_than_one_page_only_retrieve_first_page_of_resource()
        {
            AssertResourcePaging(0, _totalCountOfResourceOfLessThanOnePage);
        }

        [Fact]
        public void when_more_than_one_page_retrieve_first_page_by_default()
        {
            AssertResourcePaging(0, _totalCountOfResourceOfThreePages);
        }

        [Fact]
        public void when_more_than_two_page_of_resource_can_get_two_page_of_resources()
        {
            AssertResourcePaging(1, _totalCountOfResourceOfThreePages);
        }

        [Fact]
        public void when_has_three_pages_of_resources_can_get_all_three_pages()
        {
            AssertResourcePaging(2, _totalCountOfResourceOfThreePages);
        }

        [Fact]
        public void resource_list_should_ordered_by_datetime_descending()
        {
            AddResources(_totalCountOfResourceOfThreePages);

            var resources = _resourceRepositorySUT.GetResourceList(0);

            AssertResourceOrderByLastupdateTimeDescending(resources);

        }
        #endregion

        #region Save Resource
        [Fact]
        public void resource_can_be_save()
        {
            //Arrange
            _session.Setup(s => s.SaveChanges()).Verifiable();

            //Act
            _resourceRepositorySUT.Save();

            //Assert
            _session.VerifyAll();
        }
        #endregion

        #region Tag function
        [Fact]
        public void should_return_resource_by_given_tag()
        {
            // Arrange
            _session.SetupQueryResult(typeof(ResourceIndexByTag).Name, 10.CountOfResouces("agile"));

            // Act
            var result = _resourceRepositorySUT.GetResourceListByTag("agile");

            // Assert
            Assert.Equal(10, result.Count);
        }

        [Fact]
        public void case_of_tag_letter_will_be_ignored()
        {
            // Arrange
            List<Resource> resourceList = GetResourceListWithLowerAndUpperCaseTag();
            _session.SetupQueryResult(typeof(ResourceIndexByTag).Name, resourceList);

            // Act
            var result = _resourceRepositorySUT.GetResourceListByTag("case");

            // Assert
            Assert.Equal(2, result.Count);
        }
        #endregion

        #region Private functions
        private void AssertResourceOrderByLastupdateTimeDescending(List<Resource> resources)
        {
            using (IEnumerator<Resource> e = resources.GetEnumerator())
            {
                Resource current;
                bool hasNext = true;
                while (hasNext)
                {
                    e.MoveNext();
                    current = e.Current;
                    hasNext = e.MoveNext();
                    if (hasNext)
                        Assert.True(current.LastUpdateTime >= e.Current.LastUpdateTime);
                }
            }
        }

        private string DocumentId(string id)
        {
            return string.Format("resources/{0}", id);
        }

        private List<Resource> GetResourceListWithLowerAndUpperCaseTag()
        {
            var resource1 = Resource.DefaultResource().WithTag("case");
            var resource2 = Resource.DefaultResource().WithTag("CASE");

            var resourceList = new List<Resource>();
            resourceList.Add(resource1);
            resourceList.Add(resource2);
            return resourceList;
        }

        private void AssertResourcePaging(int currentPage, int totalCountOfResource)
        {
            AddResources(totalCountOfResource);

            var resources = _resourceRepositorySUT.GetResourceList(currentPage);

            int expectedCount = GetExpectedCountOfResource(currentPage, totalCountOfResource);

            Assert.Equal(expectedCount, resources.Count);

            _session.VerifyAll();
        }

        private void AddResources(int count)
        {
            _session.SetupQueryResult(typeof(ResourceIndexByTitle).Name, count.CountOfResouces("tag"));
        }

        private int GetExpectedCountOfResource(int currentPage, int totalCountOfResource)
        {
            _resourceCountNextPage = ((totalCountOfResource - currentPage * 20) < 20) ? (totalCountOfResource - currentPage * 20) : 20;

            int resourceCount = _resourceCountNextPage;
            return resourceCount; 
        }
        #endregion
    }
}


