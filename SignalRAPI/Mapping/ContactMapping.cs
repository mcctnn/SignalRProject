using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDto.ContactDto;

namespace SignalRAPI.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact,ResultContactDto>().ReverseMap();
            CreateMap<Contact,CreateContactDto>().ReverseMap();
            CreateMap<Contact,UpdateContactDto>().ReverseMap();
            CreateMap<Contact,GetContactDto>().ReverseMap();
        }
    }
}
