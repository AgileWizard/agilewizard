using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Raven.Database.Data;
using AgileWizard.Domain;

namespace AgileWizard.AcceptanceTests.Data
{
    public class DataManager
    {
        private IDocumentStore DocumentStore { get; set; }

        public DataManager(IDocumentStore store)
        {
            this.DocumentStore = store;
        }

        public void ClearAllDocuments()
        {
            DocumentStore.DatabaseCommands.DeleteByIndex("Raven/DocumentsByEntityName", new IndexQuery(), true);
        }

        public void InitData()
        {
            var session = DocumentStore.OpenSession();
            var users = AddUsers();
            foreach (var x in users)
            {
                session.Store(x);
            }

            session.SaveChanges();
            session.Clear();
        }

        public IList<User> AddUsers()
        {
            return new List<User>{
                new User { UserName = "agilewizard", Password = "agilewizard" }
            };
        }

    }
}
