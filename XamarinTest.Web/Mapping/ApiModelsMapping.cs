using AutoMapper;
using XamarinTest.ApiModels.Models;
using XamarinTest.Domain.Entities;

namespace XamarinTest.Web.Mapping {
    public class ApiModelsMapping : Profile {
        public ApiModelsMapping() {
            CreateMap<ImageApiModel, Image>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ImageBytes, opt => opt.MapFrom(src => src.ImageBytes))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ReverseMap();
        }
    }
}