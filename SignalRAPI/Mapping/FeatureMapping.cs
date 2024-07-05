using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDto.FeatureDto;

namespace SignalRAPI.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
            CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature,GetFeatureDto>().ReverseMap();
        }
    }
}
