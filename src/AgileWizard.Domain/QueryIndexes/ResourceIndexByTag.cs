using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.QueryIndexes
{
    public class ResourceIndexByTag : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinition<Resource>
            {
                Map = resources => from resource in resources
                                   from tag in resource.Tags
                                   select new { tag.Name },
            }
            .ToIndexDefinition(DocumentStore.Conventions);
        }
    }
}
