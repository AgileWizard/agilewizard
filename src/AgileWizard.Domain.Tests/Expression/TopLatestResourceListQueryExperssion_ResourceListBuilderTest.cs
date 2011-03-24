using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Domain.Tests.Expression
{
    public class TopLatestResourceListQueryExperssion_ResourceListBuilderTest
    {
        protected QueryExpression _resourceListQueryExpression;
        protected readonly IList<Resource> _resources;
        protected IList<Resource> _actualResources;

        public TopLatestResourceListQueryExperssion_ResourceListBuilderTest()
        {
            _resources = 41.CountOfResouces("agile");
            _resources = _resources.OrderBy(r => r.CreateTime).ToList();

            _resourceListQueryExpression = QueryExpressionBuilder.BuildTopLatestResourceList_QueryExperssion();

            _actualResources = _resources.Where(_resourceListQueryExpression.Condition.Compile()).OrderByDescending(_resourceListQueryExpression.OrderByColumn.Compile()).Take(_resourceListQueryExpression.PageSize).ToList();
        }

        [Fact]
        public void Get_TopLatest()
        {
            AssertGet_LatestResource();
        }

        [Fact]
        public void Orderby_Latest()
        {
            AssertResource_OrderByLatest_Descending(_actualResources);
        }

        [Fact]
        public void PageSize_3()
        {
            Assert.Equal(3, _actualResources.Count);
        }

        private void AssertGet_LatestResource()
        {
            Assert.Equal(_resources[40].CreateTime, _actualResources[0].CreateTime);
            Assert.Equal(_resources[39].CreateTime, _actualResources[1].CreateTime);
            Assert.Equal(_resources[38].CreateTime, _actualResources[2].CreateTime);
        }

        private void AssertResource_OrderByLatest_Descending(IEnumerable<Resource> resources)
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
                        Assert.True(current.CreateTime >= e.Current.CreateTime);
                }
            }
        }
    }
}
