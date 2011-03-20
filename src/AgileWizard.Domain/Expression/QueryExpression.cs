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
        public Expression<Func<Resource, DateTime>> OrderBy { get; set; }
        public int PageSize { get; set; }
    }

    public class ResourceListQueryExpression : QueryExpression
    {
        internal ResourceListQueryExpression(long ticksOfCreateTime)
        {
            IndexName = typeof (ResourceIndexByTitle).Name;
            Condition = x => x.CreateTime.Ticks < ticksOfCreateTime;
            OrderBy = x => x.CreateTime;
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
            OrderBy = x => x.CreateTime;
            PageSize = 20;
        }
    }
}
