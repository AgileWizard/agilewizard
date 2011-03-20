using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using Xunit;


namespace AgileWizard.Domain.Tests.Expression
{
    public class QueryByExpression_ResourceListBuilderTest
    {
        private readonly QueryExpression _resourceListQueryExpression;
        private readonly IList<Resource> _resources;
        private readonly IList<Resource> _actualResource;

        public QueryByExpression_ResourceListBuilderTest()
        {
            _resources = 41.CountOfResouces("agile");

            _resourceListQueryExpression = QueryExpressionBuilder.BuildResourceList_QueryExpression(_resources[19].CreateTime.Ticks);

            _actualResource = _resources.Where(_resourceListQueryExpression.Condition.Compile()).OrderByDescending(_resourceListQueryExpression.OrderBy.Compile()).Take(_resourceListQueryExpression.PageSize).ToList();
        }

        [Fact]
        public void OlderThan_CreateTime()
        {
            Assert.True(_resources[19].CreateTime > _actualResource[0].CreateTime);
        }

        [Fact]
        public void OrderBy_CreateTime_Desc()
        {
            AssertResourceOrderByLastupdateTimeDescending(_actualResource);
        }

        [Fact]
        public void PageSize_20()
        {
            Assert.Equal(20, _actualResource.Count);
        }

        private void AssertResourceOrderByLastupdateTimeDescending(IEnumerable<Resource> resources)
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
