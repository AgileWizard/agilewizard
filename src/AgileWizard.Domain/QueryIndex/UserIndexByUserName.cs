using System.Linq;
using Raven.Database.Indexing;
using Raven.Client.Indexes;

namespace AgileWizard.Domain.QueryIndex
{
    public class UserIndexByUserName : AbstractIndexCreationTask
    {
        public override IndexDefinition  CreateIndexDefinition()
        {
            return new IndexDefinition<User>
            {
                Map = users => from user in users
                              select new {user.UserName }
            }
            .ToIndexDefinition(DocumentStore.Conventions);
        }

    }
}
