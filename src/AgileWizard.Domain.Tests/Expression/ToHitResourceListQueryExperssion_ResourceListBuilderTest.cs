using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Domain.Tests.Expression
{
    public class ToHitResourceListQueryExperssion_ResourceListBuilderTest
    {
        protected QueryExpression _resourceListQueryExpression;
        protected readonly IList<Resource> _resources;
        protected IList<Resource> _actualResources;

        public ToHitResourceListQueryExperssion_ResourceListBuilderTest()
        {
            _resources = 41.CountOfResouces("agile");

            _resourceListQueryExpression = QueryExpressionBuilder.BuildTopHitResourceList_QueryExperssion();

            _actualResources = _resources.Where(_resourceListQueryExpression.Condition.Compile()).OrderByDescending(_resourceListQueryExpression.OrderByColumn.Compile()).Take(_resourceListQueryExpression.PageSize).ToList();
        }

        [Fact]
        public void Get_TopHit()
        {
            AssertGet_TopHitResource();
        }

        [Fact]
        public void Orderby_Hit()
        {
            AssertResource_OrderByHit_Descending(_actualResources);
        }

        [Fact]
        public void PageSize_3()
        {
            Assert.Equal(3, _actualResources.Count);
        }

        private void AssertGet_TopHitResource()
        {
            Assert.Equal(_resources[40].PageView, _actualResources[0].PageView);
            Assert.Equal(_resources[39].PageView, _actualResources[1].PageView);
            Assert.Equal(_resources[38].PageView, _actualResources[2].PageView);
        }

        private void AssertResource_OrderByHit_Descending(IEnumerable<Resource> resources)
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
                        Assert.True(current.PageView >= e.Current.PageView);
                }
            }
        }
    }
}
