using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Database.Indexing;

namespace AgileWizard.Domain.QueryIndex
{
    public class ResourceIndexByTitle : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinition<Resource>
            {
                Map = resources => from resource in resources
                                   select new { Title = resource.Title }
            }
            .ToIndexDefinition(DocumentStore.Conventions);
        }
    }
}
