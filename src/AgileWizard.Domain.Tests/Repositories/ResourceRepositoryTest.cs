using System;
using System.Collections.Generic;
using AgileWizard.Domain.Resources;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Domain.Repositories;
using Xunit;

namespace AgileWizard.Domain.Tests.Repositories
{
    public class ResourceRepositoryTest : RepositoryTestBase
    {
        private readonly ResourceRepository _resourceRepositorySUT;

        public ResourceRepositoryTest()
        {
            _resourceRepositorySUT = new ResourceRepository(_session.Object);
        }

        [Fact]
        public void add_resource()
        {
            //Arrange
            const string TITLE = "title";
            const string CONTENT = "content";
            const string AUTHOR = "author";
            const string SUBMITUSER = "submit user";
            _session.SetupStoreExpectation<Resource>(r => r.Title == TITLE && r.Content == CONTENT && r.Author == AUTHOR && r.SubmitUser == SUBMITUSER);

            //Act
            var resource = _resourceRepositorySUT.Add(TITLE, CONTENT, AUTHOR, SUBMITUSER);

            //Assert
            _session.VerifyAll();
            Assert.Equal(TITLE, resource.Title);
            Assert.Equal(CONTENT, resource.Content);
            Assert.Equal(AUTHOR, resource.Author);
            Assert.Equal(SUBMITUSER, resource.SubmitUser);
        }

        [Fact]
        public void can_get_one_resource_with_given_id()
        {
            //Arrange
            const string ID = "1";
            _session.Setup(s => s.Load<Resource>(DocumentId(ID))).Verifiable();

            //Act
            _resourceRepositorySUT.GetResourceById(ID);

            //Assert
            _session.VerifyAll();
        }

        [Fact]
        public void can_get_first_100_list_of_resources()
        {
            _session.SetupQueryResult<Resource>(typeof(ResourceIndexByTitle).Name, 101.CountOfResouces());

            var resources = _resourceRepositorySUT.GetResourceList();

            Assert.Equal(resources.Count, 100);
            _session.VerifyAll();
        }

        [Fact]
        public void can_calculate_resources_total_count()
        {
            _session.SetupQueryResult<Resource>(typeof(ResourceIndexByTitle).Name, 200.CountOfResouces());

            int count = _resourceRepositorySUT.GetResourcesTotalCount();

            Assert.Equal(count, 200);
            _session.VerifyAll();
        }

        [Fact]
        public void resource_list_should_sort_descending()
        {
            _session.SetupQueryResult<Resource>(typeof(ResourceIndexByTitle).Name, 101.CountOfResouces());

            var resources = _resourceRepositorySUT.GetResourceList();

            AssertResourceOrderByLastupdateTimeDescending(resources);

        }

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

        private void AssertResourceOrderByLastupdateTimeDescending(List<Resource> resources)
        {
            using (IEnumerator<Resource> e = resources.GetEnumerator())
            {
                Resource current;
                bool hasNext = true;
                while (hasNext)
                {
                    hasNext = e.MoveNext();
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
    }

    internal static class ResourcesGenerator
    {
        internal static IEnumerable<Resource> CountOfResouces(this int totalCount)
        {
            for (int i = 0; i < totalCount; i++)
                yield return new Resource
                {
                    Author = "agilewizard",
                    Content = "agilewizard blog number" + i,
                    CreateTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    Title = "agilewizard",
                    Id = (i + 1).ToString(),
                    SubmitUser = "user"
                };
        }
    }
}


