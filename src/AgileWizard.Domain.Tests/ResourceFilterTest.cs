using System;
using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Services;
using Xunit;

namespace AgileWizard.Domain.Tests
{
    public class ResourceFilterTest
    {
        private readonly ResourceFilter _resourceFilterSut;

        public ResourceFilterTest()
        {
            _resourceFilterSut = new ResourceFilter();
        }

        [Fact]
        public void WhenLessThan_OnePage_Retrieve_All()
        {
            var expectedResources = 11.CountOfResouces("tag");

            var actualResources = _resourceFilterSut.Filter(expectedResources, DateTime.Now.Ticks).ToList();

            Assert.Equal(expectedResources.Count, actualResources.Count);
        }

        [Fact]
        public void WhenMoreThan_OnePage_RetrieveOnePage_Maximum()
        {
            var expectedResources = 41.CountOfResouces("tag");

            var actualResources = _resourceFilterSut.Filter(expectedResources, DateTime.Now.Ticks).ToList();

            Assert.Equal(20, actualResources.Count);
        }

        [Fact]
        public void ResourceOfNextPage_ShouldOlderThan_NotEqualTo_LastResourceOfCurrentPage()
        {
            var expectedResources = 41.CountOfResouces("tag");

            var actualResources = _resourceFilterSut.Filter(expectedResources, expectedResources[20].CreateTime.Ticks).ToList();

            Assert.Equal(expectedResources[21].Id, actualResources[0].Id);
        }

        [Fact]
        public void ResourceList_ShouldBeOrderedBy_DateTimeDesc()
        {
            var expectedResources = 41.CountOfResouces("tag");

            var actualResources = _resourceFilterSut.Filter(expectedResources, DateTime.Now.Ticks).ToList();

            Assert_ResourceOrderBy_LastupdateTimeDescending(actualResources);
        }

        private void Assert_ResourceOrderBy_LastupdateTimeDescending(IEnumerable<Resource> resources)
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
    }
}
