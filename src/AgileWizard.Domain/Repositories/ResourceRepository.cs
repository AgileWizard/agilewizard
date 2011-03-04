using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;
using System.Linq;

namespace AgileWizard.Domain.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IDocumentSession _documentSession;
        private int _countOfResourceToSkip;
        private const int _maxItemsInList = 20;

        public ResourceRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public Resource Add(Resource resource)
        {

            _documentSession.Store(resource);
            return resource;

        }

        public Resource GetResourceById(string id)
        {
            return _documentSession.Load<Resource>(string.Format("resources/{0}", id));
        }

        public List<Resource> GetResourceList(int startingPage)
        {
            var query = (IEnumerable<Resource>)_documentSession.Query<Resource>(typeof(ResourceIndexByTitle).Name);

            _countOfResourceToSkip = startingPage * _maxItemsInList;
            
            return query.OrderByDescending(x => x.LastUpdateTime).Skip(_countOfResourceToSkip).Take(_maxItemsInList).ToList();
        }

        public void Save()
        {
            _documentSession.SaveChanges();
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
                         where tag.Name.ToLower() == tagName.ToLower()
                         select resource;

            return result;
        }
    }
}