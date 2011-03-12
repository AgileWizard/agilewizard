using System.Collections.Generic;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Mapper;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Helper
{
    public class ResourceListViewService : IResourceListViewService
    {
        private IResourceService ResourceService { get; set; }
        private IResourceMapper ResourceMapper { get; set; }

        public ResourceListViewService(IResourceService resourceService, IResourceMapper resourceMapper)
        {
            ResourceService = resourceService;
            ResourceMapper = resourceMapper;
        }

        public IList<ResourceListViewModel> GetNextPageOfResource(long ticksOfLastCreateTime)
        {
            var resources = ResourceService.GetNextPageOfResource(ticksOfLastCreateTime);
            var resourceListViewModel = ResourceMapper.MapFromDomainListToListViewModel(resources);
            return resourceListViewModel;
        }
    }
}