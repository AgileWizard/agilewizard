using System.Collections.Generic;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Repositories
{
    public interface IResourceRepository
    {
        Resource Add(Resource resource);
        Resource GetResourceById(string id);
        List<Resource> GetResourceList();
        int GetResourcesTotalCount();
        void Save();
        void InsertResourceLog(ResourceLog resourceLog);
        ResourceCounter GetResourceCounter(string resourceId, string counterName);
    }
}