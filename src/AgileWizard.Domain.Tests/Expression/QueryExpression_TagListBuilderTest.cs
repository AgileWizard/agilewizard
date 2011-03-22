using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using Xunit;

namespace AgileWizard.Domain.Tests.Expression
{
    public class QueryExpression_TagListBuilderTest : ResourceListQueryExpression_TestBase
    {
        public QueryExpression_TagListBuilderTest()
        {
            ((List<Resource>)_resources).AddRange(10.CountOfResouces("tag").ToList());

            _resourceListQueryExpression = QueryExpressionBuilder.BuildTagResourceList_QueryExpression(_resources[19].CreateTime.Ticks, "agile");

            _actualResources = _resources.Where(_resourceListQueryExpression.Condition.Compile()).OrderByDescending(_resourceListQueryExpression.OrderByColumn.Compile()).Take(_resourceListQueryExpression.PageSize).ToList();
        }

        [Fact]
        public void Has_This_Tag()
        {
            foreach (var resource in _actualResources)
                Assert.Equal(resource.Tags[0].Name.ToLower(), "agile");
        }

        [Fact]
        public void CaseOfTag_Ignored()
        {
            foreach (var resource in _actualResources)
                Assert.Equal(resource.Tags[0].Name.ToLower(), "agile");
        }
    }
}
