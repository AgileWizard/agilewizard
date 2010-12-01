using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.AcceptanceTests.Helper;
using Raven.Client;
using Raven.Database.Data;
using AgileWizard.Domain;

namespace AgileWizard.AcceptanceTests.Data
{
    public class DataManager
    {
        private const string PermantIndex = "Raven/DocumentsByEntityName";

        private IDocumentStore DocumentStore { get; set; }

        public DataManager(IDocumentStore store)
        {
            this.DocumentStore = store;
        }

        public void ClearAllDocuments()
        {
            DocumentStore.DatabaseCommands.DeleteByIndex(PermantIndex, new IndexQuery(), true);
        }

        public void InitData()
        {
            var session = DocumentStore.OpenSession();
            var entities = new List<object>();
            entities.AddRange(AddUsers());
            entities.AddRange(AddResources());
            foreach (var x in entities)
            {
                session.Store(x);
            }

            session.SaveChanges();

            //query user back to wait index update
            session.Query<User>(PermantIndex).Customize(x => x.WaitForNonStaleResults()).FirstOrDefault();

            session.Clear();
        }

        public IList<User> AddUsers()
        {
            return new List<User>{
                new User { UserName = BrowserHelper.UserName, Password = BrowserHelper.Password }
            };
        }

        public IList<Resource> AddResources()
        {
            return new List<Resource>
                       {
                           new Resource
                               {
                                   Title = "Embeded Video",
                                   Content =
                                       @"<embed src=""http://player.youku.com/player.php/sid/XMjI2MjI2MTQw/v.swf"" quality=""high"" width=""480"" height=""400"" align=""middle"" allowScriptAccess=""sameDomain"" type=""application/x-shockwave-flash""></embed>"
                               }
                       };
        }

    }
}
