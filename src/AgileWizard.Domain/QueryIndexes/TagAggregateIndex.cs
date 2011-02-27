using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using AgileWizard.Domain.Models;
using Raven.Client.Document;

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
                                  LastUpdateTicks = g.Max(x => (long)x.LastUpdateTicks),
                              };

            Index(x => x.Name, FieldIndexing.NotAnalyzed);
            Index(x => x.LastUpdateTicks, FieldIndexing.Analyzed);
                 

        }

        //public override IndexDefinition CreateIndexDefinition()
        //{
        //    return new IndexDefinition<Resource, Tag>
        //    {
        //        Map = resources => from resource in resources
        //                           from tag in resource.Tags
        //                           select new
        //                           {
        //                               Name = tag.Name.ToLower(),
        //                           },

        //        Reduce = items => from item in items
        //                          group item by item.Name into g
        //                          let lastUpdateTime = g.Max(x => x.LastUpdateTime)
        //                          let totalCount = g.Count()
        //                          select new
        //                          {
        //                              Name = g.Key,
        //                              TotalCount = totalCount,
        //                              LastUpdateTime = lastUpdateTime,
        //                          },

        //    }.ToIndexDefinition(new DocumentConvention());

        //}
    }
}
