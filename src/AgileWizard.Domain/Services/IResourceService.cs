using System.Collections.Generic;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Services
{
    public interface IResourceService
    {
        Resource AddResource(Resource resource);
        Resource GetResourceById(string id);
        int GetResourcesTotalCountForTag(string tagName);
        void UpdateResource(string id, Resource resource);
        void LikeThisResource(string resourceId);
        void DislikeThisResource(string resourceId);

        IList<Resource> GetResourceList(long ticksOfCreateTime);
        IList<Resource> GetResourceListByTag(long ticksOfCreateTime, string tagName);
        IList<Resource> GetLikeList();
        IList<Resource> GetHitList();
    }
}
