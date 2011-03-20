using System.Collections.Generic;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Helper
{
    public interface IResourceListViewProcessor
    {
        IList<ResourceListViewModel> Process(IList<Resource> resources, ViewDataDictionary viewdata);
    }
}