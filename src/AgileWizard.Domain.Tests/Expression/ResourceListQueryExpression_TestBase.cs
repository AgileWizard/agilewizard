using System.Collections.Generic;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Domain.Tests.Expression
{
    public abstract class ResourceListQueryExpression_TestBase
    {
        protected QueryExpression _resourceListQueryExpression;
        protected readonly IList<Resource> _resources;
        protected IList<Resource> _actualResources;

        protected ResourceListQueryExpression_TestBase()
        {
            _resources = 41.CountOfResouces("agile");
        }

        [Fact]
        public void OlderBy_CreateTime()
        {
            Assert.True(_resources[19].CreateTime > _actualResources[0].CreateTime);
        }

        [Fact]
        public void OrderBy_CreateTime_Desc()
        {
            AssertResource_OrderByLastupdateTime_Descending(_actualResources);
        }

        [Fact]
        public void PageSize_20()
        {
            Assert.Equal(20, _actualResources.Count);
        }

        private void AssertResource_OrderByLastupdateTime_Descending(IEnumerable<Resource> resources)
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
