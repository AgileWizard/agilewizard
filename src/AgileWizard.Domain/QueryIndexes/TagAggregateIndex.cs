using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.QueryIndexes
{
    public class TagAggregateIndex : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinition<Resource, Tag>
            {
                Map = resources => from resource in resources
                                   from tag in resource.Tags
                                   select new
                                   {
                                       Name = tag.Name.ToLower(),
                                       ShortTicks = resource.ShortTicks,
                                   },

                Reduce = items => from item in items
                                  group item by item.Name into g
                                  let shortTicks = g.Max(x => x.ShortTicks)
                                  let totalCount = g.Count()
                                  orderby shortTicks descending, g.Key
                                  select new
                                  {
                                      Name = g.Key,
                                      TotalCount = totalCount,
                                      ShortTicks = shortTicks,
                                  },

            }.ToIndexDefinition(DocumentStore.Conventions);

        }
    }
}
