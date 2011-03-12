using System.Collections.Generic;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Helper
{
    public interface IResourceListViewService
    {
        IList<ResourceListViewModel> GetNextPageOfResource(long ticksOfLastCreateTime);
    }
}