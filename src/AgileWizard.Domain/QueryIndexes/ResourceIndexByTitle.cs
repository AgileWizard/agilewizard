using System.Linq;
using AgileWizard.Domain.Resources;
using Raven.Client.Indexes;
using Raven.Database.Indexing;

namespace AgileWizard.Domain.QueryIndexes
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
