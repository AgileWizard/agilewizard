using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Users;
using Raven.Client;
using Raven.Database.Data;
using AgileWizard.Domain;

namespace AgileWizard.Data
{
    public class DataManager
    {
        public const string PermantIndex = "Raven/DocumentsByEntityName";

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
