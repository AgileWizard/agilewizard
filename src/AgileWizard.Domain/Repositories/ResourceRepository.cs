using System.Collections.Generic;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;
using System.Linq;

namespace AgileWizard.Domain.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IDocumentSession _documentSession;

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

        public void Save()
        {
            _documentSession.SaveChanges();
        }

        public IEnumerable<Resource> GetList(QueryExpression queryExpression)
        {
            return _documentSession.Query<Resource>(queryExpression.IndexName).Where(queryExpression.Condition.Compile()).
                OrderByDescending(queryExpression.OrderBy.Compile()).Take(queryExpression.PageSize);
        }

        public int GetResourcesTotalCountForTag(string tagName)
        {
            return GetQuery_ResourceListByTag(tagName).Count();
        }

        private IEnumerable<Resource> GetQuery_ResourceListByTag(string tagName)
        {
            var query = _documentSession.Query<Resource>(typeof(ResourceIndexByTag).Name);

            var result = from resource in query
                         from tag in resource.Tags
                         where tag.Name.ToLower() == tagName.ToLower()
                         select resource;

            return result;
        }
    }
}