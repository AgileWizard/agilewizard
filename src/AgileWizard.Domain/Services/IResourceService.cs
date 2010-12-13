using System.Collections.Generic;
using AgileWizard.Domain.Entities;

namespace AgileWizard.Domain.Services
{
    public interface IResourceService
    {
        Resource AddResource(string title, string content, string author, string submitUser);
        Resource GetResourceById(string id);
        IList<Resource> GetResourceList();
        int GetResourcesTotalCount();
        void UpdateResource(string id, Resource resource);
    }
}
