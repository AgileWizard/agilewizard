using System.Collections.Generic;
using AgileWizard.Domain.Resources;

namespace AgileWizard.Domain.Services
{
    public interface IResourceService
    {
        Resource AddResource(string title, string content, string author, string submitUser, List<Tag> tags);
        Resource GetResourceById(string id);
        IList<Resource> GetResourceList();
        int GetResourcesTotalCount();
        void UpdateResource(string id, Resource resource);
    }
}
