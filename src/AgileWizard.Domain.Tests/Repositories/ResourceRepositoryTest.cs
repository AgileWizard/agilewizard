using System.Collections.Generic;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Tests.Helper;
using Xunit;

namespace AgileWizard.Domain.Tests.Repositories
{
    public class ResourceRepositoryTest : RepositoryTestBase
    {
        private readonly ResourceRepository _resourceRepositorySUT;
        private IList<Resource> _resourceList;

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

            var resourceList = new List<Resource> {resource1, resource2};
            return resourceList;
        }

        private void AddResources(int count)
        {
            _resourceList = count.CountOfResouces("tag");
            _session.SetupQueryResult(typeof(ResourceIndexByTitle).Name, _resourceList);
        }

        #endregion
    }
}


