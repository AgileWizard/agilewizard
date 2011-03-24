using System;
using System.Linq;
using System.Linq.Expressions;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.QueryIndexes;

namespace AgileWizard.Domain.Expression
{
    public class QueryExpression
    {
        public string IndexName { get; set; }
        public Expression<Func<Resource, bool>> Condition { get; set; }
        // use Expression<Func<Resource, long>> to cover two kinds of orderbycolumn which are DateTime and Int, there will be performance loss 
        public Expression<Func<Resource, long>> OrderByColumn { get; set; }
        public int PageSize { get; set; }
    }

    public class ResourceListQueryExpression : QueryExpression
    {
        internal ResourceListQueryExpression(long ticksOfCreateTime)
        {
            IndexName = typeof (ResourceIndexByTitle).Name;
            Condition = x => x.CreateTime.Ticks < ticksOfCreateTime;
            OrderByColumn = x => x.CreateTime.Ticks;
            PageSize = 20;
        }
    }

    public class TagResourceListQueryExperssion : QueryExpression
    {
        internal TagResourceListQueryExperssion(long ticksOfCreateTime, string tagName)
        {
            IndexName = typeof (ResourceIndexByTag).Name;
            Condition =
                x =>
                x.CreateTime.Ticks < ticksOfCreateTime && x.Tags != null &&
                x.Tags.Any(y => y.Name.ToLower() == tagName.ToLower());
            OrderByColumn = x => x.CreateTime.Ticks;
            PageSize = 20;
        }
    }

    public class TopLikeResourceListQueryExperssion : QueryExpression
    {
        internal TopLikeResourceListQueryExperssion()
        {
            IndexName = typeof(ResourceIndexByTitle).Name;
            Condition =
                x => true;
            OrderByColumn = x => x.Like;
            PageSize = 3;
        }
    }


    public class TopHitResourceListQueryExperssion : QueryExpression
    {
        internal TopHitResourceListQueryExperssion()
        {
            IndexName = typeof(ResourceIndexByTitle).Name;
            Condition =
                x => true;
            OrderByColumn = x => x.PageView;
            PageSize = 3;
        }
    }

    public class TopLatestResourceListQueryExperssion : QueryExpression
    {
        internal TopLatestResourceListQueryExperssion()
        {
            IndexName = typeof(ResourceIndexByTitle).Name;
            Condition =
                x => true;
            OrderByColumn = x => x.CreateTime.Ticks;
            PageSize = 3;
        }
    }
}
