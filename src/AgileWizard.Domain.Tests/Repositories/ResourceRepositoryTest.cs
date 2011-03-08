﻿using System;
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

        public ResourceRepositoryTest()
        {
            _resourceRepositorySUT = new ResourceRepository(_session.Object);
        }

        [Fact]
        public void add_resource()
        {
            //Arrange
            var resource = Resource.DefaultResource();

            //Act
            var actualResource = _resourceRepositorySUT.Add(resource);

            //Assert
            _session.Verify(r => r.Store(resource));
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
            _session.SetupQueryResult(typeof(ResourceIndexByTitle).Name, 101.CountOfResouces("tag"));

            var resources = _resourceRepositorySUT.GetResourceList();

            Assert.Equal(resources.Count, 100);
            _session.VerifyAll();
        }

        [Fact]
        public void can_calculate_resources_total_count()
        {
            _session.SetupQueryResult(typeof(ResourceIndexByTitle).Name, 200.CountOfResouces("tag"));

            int count = _resourceRepositorySUT.GetResourcesTotalCount();

            Assert.Equal(count, 200);
            _session.VerifyAll();
        }

        [Fact]
        public void resource_list_should_sort_descending()
        {
            _session.SetupQueryResult(typeof(ResourceIndexByTitle).Name, 101.CountOfResouces("tag"));

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

    }

    internal static class ResourcesGenerator
    {
        internal static IEnumerable<Resource> CountOfResouces(this int totalCount, string tags)
        {
            var tagList = tags.ToTagList();

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


