using AutoMapper;
using XamarinTest.ApiModels.Models;
using XamarinTest.Models;

namespace XamarinTest.Mapping {
    internal class ApiModelsMapping : Profile {
        public ApiModelsMapping() {
            CreateMap<ImageModel, ImageApiModel>()
                .ForMember(dest => dest.ImageBytes, opt => opt.MapFrom(src => src.Bytes))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ReverseMap()
                .ForMember(dest => dest.ImageSource, opt => opt.Ignore());
        }
    }
}
