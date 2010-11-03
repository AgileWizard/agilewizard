using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Client.Document;
using Raven.Client;

namespace AgileWizard.Domain.QueryIndex
{
    public class IndexRegister
    {
        public void RegisterAt(IDocumentStore store)
        {
            IndexCreation.CreateIndexes(this.GetType().Assembly, store);
        }
    }
}
