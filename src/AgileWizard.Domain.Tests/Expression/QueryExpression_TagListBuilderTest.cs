using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Domain.Tests.Expression
{
    public class QueryExpression_TagListBuilderTest
    {
         private readonly QueryExpression _resourceListQueryExpression;
        private readonly IList<Resource> _resources;
        private readonly IList<Resource> _actualResource;

        public QueryExpression_TagListBuilderTest()
        {
            _resources = 41.CountOfResouces("Agile").ToList();
            ((List<Resource>)_resources).AddRange(10.CountOfResouces("tag").ToList());

            _resourceListQueryExpression = QueryExpressionBuilder.BuildTagResourceList_QueryExpression(_resources[19].CreateTime.Ticks, "agile");

            _actualResource = _resources.Where(_resourceListQueryExpression.Condition.Compile()).OrderByDescending(_resourceListQueryExpression.OrderBy.Compile()).Take(_resourceListQueryExpression.PageSize).ToList();
        }

        [Fact]
        public void OlderThan_CreateTime()
        {
            Assert.True(_resources[19].CreateTime > _actualResource[0].CreateTime);
        }

        [Fact]
        public void Has_This_Tag()
        {
            foreach (var resource in _actualResource)
                Assert.Equal(resource.Tags[0].Name.ToLower(), "agile");
        }

        [Fact]
        public void CaseOfTag_Ignored()
        {
            foreach (var resource in _actualResource)
                Assert.Equal(resource.Tags[0].Name.ToLower(), "agile");
        }

        [Fact]
        public void OrderBy_CreateTime()
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
