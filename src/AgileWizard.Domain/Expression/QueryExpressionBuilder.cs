namespace AgileWizard.Domain.Expression
{
    public class QueryExpressionBuilder
    {
        public static QueryExpression BuildResourceList_QueryExpression(long ticksOfCreateTime)
        {
            return new ResourceListQueryExpression(ticksOfCreateTime);
        }

        public static QueryExpression BuildTagResourceList_QueryExpression(long ticksOfCreateTime, string tagName)
        {
            return new TagResourceListQueryExperssion(ticksOfCreateTime, tagName);
        }
    }
}
