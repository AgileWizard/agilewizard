using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Mapper
{
    public interface IResourceMapper
    {
        ResourceDetailViewModel MapFromDomainToDetailViewModel(Resource resource);
        Resource MapFromDetailViewModelToDomain(ResourceDetailViewModel detailViewModel);
        IList<ResourceListViewModel> MapFromDomainListToListViewModel(IList<Resource> resources, IList<ResourceListViewModel> resourceListViewModels);
    }
}