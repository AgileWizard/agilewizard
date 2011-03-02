using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Helper;
using AutoMapper;

namespace AgileWizard.Website.Models
{
    public class ResourceMapper
    {
        public static ResourceDetailViewModel MapFromDomainToDetailViewModel(Resource resource)
        {
            return Mapper.Map<Resource, ResourceDetailViewModel>(resource);
        }


        public static Resource MapFromDetailViewModelToDomain(ResourceDetailViewModel detailViewModel)
        {
            return Mapper.Map<ResourceDetailViewModel, Resource>(detailViewModel);
        }

        public static void ConfigAutoMapper()
        {
            Mapper.CreateMap<Resource, ResourceListViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Substring(10)))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => Utils.ExcerptContent(src.Content, 200)))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => Utils.FetchFirstImageUrl(src.Content)));

            Mapper.CreateMap<ResourceDetailViewModel, Resource>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.Format("resources/{0}", src.Id)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.ToTagList()));

            Mapper.CreateMap<Resource, ResourceDetailViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Substring(10)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.ToTagString()));
        }
    }
}