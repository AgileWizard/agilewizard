using System.Collections.Generic;
using AgileWizard.Domain.Entities;

namespace AgileWizard.Domain.Services
{
    public interface IResourceService
    {
        void AddResource(string title, string content);
        Resource GetResourceById(string id);
        IList<Resource> GetResourceList();
    }
}
