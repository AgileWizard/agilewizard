using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Users;
using Raven.Client;

namespace AgileWizard.Data
{
    public class DataManager
    {
        private IDocumentStore DocumentStore { get; set; }

        public DataManager(IDocumentStore store)
        {
            DocumentStore = store;
        }

        public void ClearAllDocuments()
        {
            var indexes = GetAllIndexNames();

            foreach (var x in indexes)
            {
                DocumentStore.DatabaseCommands.DeleteByIndex(x, new Raven.Database.Data.IndexQuery(), true);
            }
        }

        public void InitData()
        {
            var session = DocumentStore.OpenSession();
            var entities = new List<object>();
            entities.AddRange(AddUsers());
            //entities.AddRange(AddResources());
            foreach (var x in entities)
            {
                session.Store(x);
            }

            session.SaveChanges();

            WaitForNonStaleResults(session);

            session.Advanced.Clear();
        }

        public void InitResourceListData()
        {
            var session = DocumentStore.OpenSession();
            var entities = new List<object>();
            entities.AddRange(AddResources());
            foreach (var x in entities)
            {
                session.Store(x);
            }

            session.SaveChanges();

            WaitForNonStaleResults(session);

            session.Advanced.Clear();
        }

        public void WaitForNonStaleResults(IDocumentSession session)
        {
            var indexNames = GetAllIndexNames();

            indexNames.ForEach(x => session.Advanced.LuceneQuery<dynamic>(x).WaitForNonStaleResults().FirstOrDefault());
        }

        private List<string> GetAllIndexNames()
        {
            return DocumentStore.DatabaseCommands.GetIndexNames(0, int.MaxValue).ToList<string>();
        }

        public IList<User> AddUsers()
        {
            return new List<User>{
                new User { UserName = "agilewizard", Password = "agilewizard" }
            };
        }

        public IList<Resource> AddResources()
        {
            return 21.CountOfResouces("Agile");
        }

    }
}
