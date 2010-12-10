using System.Collections.Generic;
using AgileWizard.Domain.Entities;

namespace AgileWizard.Domain.Repositories
{
    public interface IResourceRepository
    {
        void Add(string title, string content, string author);
        Resource GetResourceById(string id);
        List<Resource> GetResourceList();
        int GetResourcesTotalCount();
        void Save();
    }
}