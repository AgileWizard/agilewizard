namespace AgileWizard.Domain.Expression
{
    public class QueryExpressionBuilder
    {
        public static ResourceListQueryExpression BuildResourceList_QueryExpression(long ticksOfCreateTime)
        {
            return new ResourceListQueryExpression(ticksOfCreateTime);
        }

        public static TagResourceListQueryExperssion BuildTagResourceList_QueryExpression(long ticksOfCreateTime, string tagName)
        {
            return new TagResourceListQueryExperssion(ticksOfCreateTime, tagName);
        }

        public static TopLikeResourceListQueryExperssion BuildTopLikeResourceList_QueryExperssion()
        {
            return new TopLikeResourceListQueryExperssion();
        }
    }
}
