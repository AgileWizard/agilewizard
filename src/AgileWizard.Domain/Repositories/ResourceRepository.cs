using System;
using System.Collections.Generic;
using AgileWizard.Domain.Resources;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;
using System.Linq;

namespace AgileWizard.Domain.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IDocumentSession _documentSession;
        private const int _maxItemsInList = 100;

        public ResourceRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public Resource Add(Resource source)
        {
            var resource = new Resource
                               {
                                   Title = source.Title,
                                   Content = source.Content,
                                   Author = source.Author,
                                   CreateTime = DateTime.Now,
                                   LastUpdateTime = DateTime.Now,
                                   SubmitUser = source.SubmitUser,
                                   Tags = source.Tags,
                                   ReferenceUrl = source.ReferenceUrl
                               };

            _documentSession.Store(resource);
            return resource;

        }

        public Resource GetResourceById(string id)
        {
            return _documentSession.Load<Resource>(string.Format("resources/{0}", id));
        }

        public List<Resource> GetResourceList()
        {
            var query = (IEnumerable<Resource>)_documentSession.Query<Resource>(typeof(ResourceIndexByTitle).Name);
            return query.OrderByDescending(x => x.LastUpdateTime).Take(_maxItemsInList).ToList();
        }

        public int GetResourcesTotalCount()
        {
            var query = (IEnumerable<Resource>)_documentSession.Query<Resource>(typeof(ResourceIndexByTitle).Name);
            return query.Count();
        }

        public void Save()
        {
            _documentSession.SaveChanges();
        }
    }
}