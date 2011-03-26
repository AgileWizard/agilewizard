using System.Linq;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.QueryIndexes
{
    public class TagAggregateIndex : AbstractIndexCreationTask<Resource, Tag>
    {

        public TagAggregateIndex()
        {
            Map = resources => from resource in resources
                               from tag in resource.Tags
                               select new
                               {
                                   Name = tag.Name.ToLower(),
                                   LastUpdateTicks = resource.LastUpdateTime.Ticks,
                               };

            Reduce = items => from item in items
                              group item by item.Name into g
                              select new
                              {
                                  Name = g.Key,
                                  TotalCount = g.Count(),
                                  LastUpdateTicks = g.Max(x => x.LastUpdateTicks),
                              };

            Index(x => x.Name, FieldIndexing.NotAnalyzed);
            Index(x => x.LastUpdateTicks, FieldIndexing.Analyzed);
        }
    }
}
