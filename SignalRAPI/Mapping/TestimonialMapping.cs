using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDto.TestimonialDto;

namespace SignalRAPI.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial,ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,GetTestimonialDto>().ReverseMap();
        }
    }
}
