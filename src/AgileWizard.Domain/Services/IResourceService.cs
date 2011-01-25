using System.Collections.Generic;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Services
{
    public interface IResourceService
    {
        Resource AddResource(Resource resource);
        Resource GetResourceById(string id);
        IList<Resource> GetResourceList();
        int GetResourcesTotalCount();
        void UpdateResource(string id, Resource resource);
        void AddOnePageView(string resourceId, string userIP);
        int GetResourceCounter(string resourceId, string counterName);
    }
}
