using System.Collections.Generic;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Helper;
using AgileWizard.Website.Models;


namespace AgileWizard.Website.Mapper
{
    public class ResourceMapper 
    {
        public static ResourceDetailViewModel MapFromDomainToDetailViewModel(Resource resource)
        {
            return AutoMapper.Mapper.Map<Resource, ResourceDetailViewModel>(resource);
        }

        public static Resource MapFromDetailViewModelToDomain(ResourceDetailViewModel detailViewModel)
        {
            return AutoMapper.Mapper.Map<ResourceDetailViewModel, Resource>(detailViewModel);
        }

        public static IList<ResourceListViewModel> MapFromDomainListToListViewModel(IList<Resource> resources, IList<ResourceListViewModel> resourceListViewModels)
        {
            return AutoMapper.Mapper.Map(resources, resourceListViewModels);
        }

        public static void ConfigAutoMapper()
        {
            AutoMapper.Mapper.CreateMap<Resource, ResourceListViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Substring(10)))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => Utils.ExcerptContent(src.Content, 200)))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => Utils.FetchFirstImageUrl(src.Content)));

            AutoMapper.Mapper.CreateMap<ResourceDetailViewModel, Resource>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.Format("resources/{0}", src.Id)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => TagHelper.ToTagList(src.Tags)));

            AutoMapper.Mapper.CreateMap<Resource, ResourceDetailViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Substring(10)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => TagsHelper.ToTagString(src.Tags)));
        }
    }
}