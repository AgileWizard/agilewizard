using System;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
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
            const string REFERENCEURL = "http://a.b.com";
            _session.SetupStoreExpectation<Resource>(r => r.Title == TITLE && r.Content == CONTENT && r.Author == AUTHOR && r.SubmitUser == SUBMITUSER);

            var source = new Resource
            {
                Title = TITLE,
                Content = CONTENT,
                Author = AUTHOR,
                SubmitUser = SUBMITUSER,
                Tags = new List<Resource.ResourceTag>(),
                ReferenceUrl = REFERENCEURL
            };

            //Act
            var resource = _resourceRepositorySUT.Add(source);

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

        [Fact]
        public void Can_record_logs_for_counter()
        {
            //Arrange
            var resourceLog = new ResourceLog { Name = "PageView", IP = "127.0.0.1", ResourceId = "80000" };
            _session.Setup(s => s.Store(resourceLog)).Verifiable();
            _session.Setup(s => s.SaveChanges()).Verifiable();

            //Act
            _resourceRepositorySUT.InsertResourceLog(resourceLog);

            //Assert
            _session.VerifyAll();
        }

        [Fact]
        public void Can_get_resource_counter()
        {
            //Arrange
            const string ID = "1";
            const string COUNTER_NAME = "PageView";
            const int COUNT = 10;
            var counters = new ResourceCounter[] { new ResourceCounter { Name = COUNTER_NAME, ResourceId = ID, Count = COUNT } };
            _session.SetupLuceneQueryResult<ResourceCounter>(typeof(ResourceLogAggregateIndex).Name, counters);

            //Act
            var counter = _resourceRepositorySUT.GetResourceCounter(ID, COUNTER_NAME);

            //Assert
            Assert.Equal(ID, counter.ResourceId);
            Assert.Equal(COUNTER_NAME, counter.Name);
            Assert.Equal(COUNT, counter.Count);
        }

        [Fact]
        public void should_return_resource_by_given_tag()
        {
            // Arrange
            _session.SetupQueryResult<Resource>(typeof(ResourceIndexByTag).Name, 10.CountOfResouces("agile"));

            // Act
            var result = _resourceRepositorySUT.GetResourceListByTag("agile");

            // Assert
            Assert.Equal(10, result.Count);
            
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
        internal static IEnumerable<Resource> CountOfResouces(this int totalCount, params string[] tags)
        {
            var tagList = new List<Resource.ResourceTag>();
            foreach (var tag in tags)
            {
                tagList.Add(new Resource.ResourceTag { Name = tag });
            }

            for (int i = 0; i < totalCount; i++)
                yield return new Resource
                {
                    Author = "agilewizard",
                    Content = "agilewizard blog number" + i,
                    CreateTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    Title = "agilewizard",
                    Id = (i + 1).ToString(),
                    SubmitUser = "user",
                    Tags = tagList,
                };
        }
    }
}


