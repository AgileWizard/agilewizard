using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Domain.Tests.Expression
{
    public class TopLikeResourceListQueryExperssion_ResourceListBuilderTest
    {
        protected QueryExpression _resourceListQueryExpression;
        protected readonly IList<Resource> _resources;
        protected IList<Resource> _actualResources;

        public TopLikeResourceListQueryExperssion_ResourceListBuilderTest()
        {
            _resources = 41.CountOfResouces("agile");

            _resourceListQueryExpression = QueryExpressionBuilder.BuildTopLikeResourceList_QueryExperssion();

            _actualResources = _resources.Where(_resourceListQueryExpression.Condition.Compile()).OrderByDescending(_resourceListQueryExpression.OrderByColumn.Compile()).Take(_resourceListQueryExpression.PageSize).ToList();
        }

        [Fact]
        public void Get_TopLike()
        {
            AssertGet_TopLikeResource();
        }

        [Fact]
        public void Orderby_Like()
        {
            AssertResource_OrderByLike_Descending(_actualResources);
        }

        [Fact]
        public void PageSize_3()
        {
            Assert.Equal(3, _actualResources.Count);
        }

        private void AssertGet_TopLikeResource()
        {
            Assert.Equal(_resources[40].Like, _actualResources[0].Like);
            Assert.Equal(_resources[39].Like, _actualResources[1].Like);
            Assert.Equal(_resources[38].Like, _actualResources[2].Like);
        }

        private void AssertResource_OrderByLike_Descending(IEnumerable<Resource> resources)
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
                        Assert.True(current.Like >= e.Current.Like);
                }
            }
        }
    }
}
