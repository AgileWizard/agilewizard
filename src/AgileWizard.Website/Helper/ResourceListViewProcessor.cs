using System.Collections.Generic;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Mapper;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Helper
{
    public class ResourceListViewProcessor : IResourceListViewProcessor
    {
        private const string TICKSOFCREATETIME = "ticksOfLastCreateTime";

        private IResourceMapper ResourceMapper { get; set; }

        public ResourceListViewProcessor(IResourceMapper resourceMapper)
        {
            ResourceMapper = resourceMapper;
        }

        public IList<ResourceListViewModel> Process(IList<Resource> resources, ViewDataDictionary viewdata, string tagName)
        {
            var resourceListViewModel = ResourceMapper.MapFromDomainListToListViewModel(resources);
            StoreTicksOfCreateTimeInViewData(resourceListViewModel, viewdata);
            viewdata["tagName"] = tagName;
            return resourceListViewModel;
        }

        private void StoreTicksOfCreateTimeInViewData(IList<ResourceListViewModel> resourceListViewModel, ViewDataDictionary viewdata)
        {
            long ticksOfCreateTime = resourceListViewModel.Count > 0 ? resourceListViewModel[resourceListViewModel.Count - 1].CreateTime.Ticks : 0;
            viewdata[TICKSOFCREATETIME] = ticksOfCreateTime;
        }
    }
}