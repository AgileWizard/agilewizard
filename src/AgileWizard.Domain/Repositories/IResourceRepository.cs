using System.Collections.Generic;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Repositories
{
    public interface IResourceRepository
    {
        Resource Add(Resource resource);
        Resource GetResourceById(string id);
        int GetResourcesTotalCountForTag(string tagName);
        void Save();
        IEnumerable<Resource> GetList(QueryExpression queryExpression);
    }
}