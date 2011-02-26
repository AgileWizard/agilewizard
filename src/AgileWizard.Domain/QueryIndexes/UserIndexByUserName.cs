using System.Linq;
using AgileWizard.Domain.Users;
using Raven.Database.Indexing;
using Raven.Client.Indexes;
using Raven.Client.Document;

namespace AgileWizard.Domain.QueryIndexes
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
            .ToIndexDefinition(new DocumentConvention());
        }

    }
}
