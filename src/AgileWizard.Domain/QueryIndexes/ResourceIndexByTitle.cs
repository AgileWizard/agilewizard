using System.Linq;
using AgileWizard.Domain.Models;
using Raven.Client.Indexes;
using Raven.Database.Indexing;



namespace AgileWizard.Domain.QueryIndexes
{
    public class ResourceIndexByTitle : AbstractIndexCreationTask<Resource>
    {
        public ResourceIndexByTitle()
        {
            Map = resources => from resource in resources
                               select new {resource.Title };

            Index(x => x.Title, FieldIndexing.Analyzed);
        }
    }
}
