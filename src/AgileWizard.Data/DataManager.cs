using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Users;
using Raven.Client;
using Raven.Database;
using AgileWizard.Domain;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client.Indexes;

namespace AgileWizard.Data
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
            return new List<Resource>
                       {
                           new Resource
                               {
                                   Title = "Embeded Video",
                                   Tags = new List<Resource.ResourceTag>
                                   {
                                       new Resource.ResourceTag
                                       {
                                           Name = "test",
                                       },
                                       new Resource.ResourceTag
                                       {
                                           Name = "html",
                                       },
                                   },
                                   CreateTime = DateTime.Now.AddMinutes(-10),
                                   LastUpdateTime = DateTime.Now.AddMinutes(-10),
                                   Content =
                                       @"<embed src=""http://player.youku.com/player.php/sid/XMjI2MjI2MTQw/v.swf"" quality=""high"" width=""480"" height=""400"" align=""middle"" allowScriptAccess=""sameDomain"" type=""application/x-shockwave-flash""></embed>"
                               },

                            new Resource
                            {
                                Title = "Tag Test",
                                Tags = new List<Resource.ResourceTag>
                                {
                                    new Resource.ResourceTag
                                    {
                                        Name = "test",
                                    },
                                    new Resource.ResourceTag
                                    {
                                        Name = "plain-text",
                                    },
                                },
                                CreateTime = DateTime.Now,
                                LastUpdateTime = DateTime.Now,
                                Content = @"just a plain text resource"
                            }
                       };
        }

    }
}
