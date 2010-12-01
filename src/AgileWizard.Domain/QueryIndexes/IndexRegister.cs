using Raven.Client.Indexes;
using Raven.Client;

namespace AgileWizard.Domain.QueryIndexes
{
    public class IndexRegister
    {
        public void RegisterAt(IDocumentStore store)
        {
            IndexCreation.CreateIndexes(this.GetType().Assembly, store);
        }
    }
}
