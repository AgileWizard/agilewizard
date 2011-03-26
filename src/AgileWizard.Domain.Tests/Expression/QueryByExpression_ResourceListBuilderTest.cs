using System.Linq;
using AgileWizard.Domain.Expression;


namespace AgileWizard.Domain.Tests.Expression
{
    public class QueryByExpression_ResourceListBuilderTest : ResourceListQueryExpression_TestBase
    {
        public QueryByExpression_ResourceListBuilderTest() 
        {
            _resourceListQueryExpression = QueryExpressionBuilder.BuildResourceList_QueryExpression(_resources[19].CreateTime.Ticks);

            _actualResources = _resources.Where(_resourceListQueryExpression.Condition.Compile()).OrderByDescending(_resourceListQueryExpression.OrderByColumn.Compile()).Take(_resourceListQueryExpression.PageSize).ToList();
        }
    }
}
