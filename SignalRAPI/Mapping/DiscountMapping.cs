using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDto.DiscountDto;

namespace SignalRAPI.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount,ResultDiscountDto>().ReverseMap();
            CreateMap<Discount,CreateDiscountDto>().ReverseMap();
            CreateMap<Discount,UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount,GetDiscountDto>().ReverseMap();
        }
    }
}
