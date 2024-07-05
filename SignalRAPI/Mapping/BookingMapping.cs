using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDto.BookingDto;

namespace SignalRAPI.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking,ResultBookingDto>().ReverseMap();
            CreateMap<Booking,CreateBookingDto>().ReverseMap();
            CreateMap<Booking,UpdateBookingDto>().ReverseMap();
            CreateMap<Booking,GetBookingDto>().ReverseMap();
        }
    }
}
