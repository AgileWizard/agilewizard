using System.Collections.Generic;
using AgileWizard.Domain.Resources;

namespace AgileWizard.Domain.Repositories
{
    public interface IResourceRepository
    {
        Resource Add(Resource resource);
        Resource GetResourceById(string id);
        List<Resource> GetResourceList();
        int GetResourcesTotalCount();
        void Save();
    }
}