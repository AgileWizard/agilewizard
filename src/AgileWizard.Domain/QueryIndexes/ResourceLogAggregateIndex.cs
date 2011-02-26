using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Models;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using Raven.Client.Document;

namespace AgileWizard.Domain.QueryIndexes
{
    public class ResourceLogAggregateIndex : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinition<ResourceLog, ResourceCounter>
                       {
                           Map = logs => from log in logs
                                         select new {log.ResourceId, log.Name},
                           Reduce = logs => from log in logs
                                            group log by new {log.ResourceId, log.Name}
                                            into g
                                            let logCount = g.Count()
                                            select
                                                new
                                                    {
                                                        Name = g.Key.Name,
                                                        ResourceId = g.Key.ResourceId,
                                                        Count = logCount
                                                    }
                       }.ToIndexDefinition(new DocumentConvention());
        }
    }
}
