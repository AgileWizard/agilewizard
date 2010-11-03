using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                              select new { UserName = user.UserName }
            }
            .ToIndexDefinition(DocumentStore.Conventions);
        }

    }
}
