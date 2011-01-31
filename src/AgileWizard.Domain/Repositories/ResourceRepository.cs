using System;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;
using System.Linq;
using Raven.Client.Linq;

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

        public void InsertResourceLog(ResourceLog resourceLog)
        {
            _documentSession.Store(resourceLog);
            _documentSession.SaveChanges();
        }

        public ResourceCounter GetResourceCounter(string resourceId, string counterName)
        {
            var query = _documentSession.LuceneQuery<ResourceCounter>(typeof (ResourceLogAggregateIndex).Name);
            return query.SingleOrDefault(c => c.Name == counterName && c.ResourceId == resourceId);
        }

        public List<Resource> GetResourceListByTag(string tagName)
        {
            return GetQuery_ResourceListByTag(tagName).Take(_maxItemsInList).ToList();
        }

        public int GetResourcesTotalCountForTag(string tagName)
        {
            return GetQuery_ResourceListByTag(tagName).Count();
        }

        private IEnumerable<Resource> GetQuery_ResourceListByTag(string tagName)
        {
            var query = _documentSession.Query<Resource>(typeof(ResourceIndexByTag).Name).ToList();

            var result = from resource in query
                         from tag in resource.Tags
                         where tag.Name == tagName
                         select resource;

            return result;
        }
    }
}