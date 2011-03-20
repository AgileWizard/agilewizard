using System.Linq;
using Raven.Client.Indexes;
using AgileWizard.Domain.Models;
using Raven.Client.Document;
using Raven.Database.Indexing;

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
                                   select new { Name = tag.Name.ToLower() },
            }
            .ToIndexDefinition(new DocumentConvention());
        }
    }
}
