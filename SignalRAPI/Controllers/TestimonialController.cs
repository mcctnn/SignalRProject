using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDto.CategoryDto;
using SignalRDto.TestimonialDto;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _service;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTestimonialList()
        {
            var result = _mapper.Map<List<ResultTestimonialDto>>(_service.TGetListAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {

            _service.TAdd(new Testimonial
            {
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Status = createTestimonialDto.Status,
                Title = createTestimonialDto.Title
            });
            return Ok("Başarıyla testimonial eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var result = _service.TGetById(id);
            _service.TDelete(result);
            return Ok("Testimonial başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _service.TUpdate(new Testimonial
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                Comment = updateTestimonialDto.Comment,
                Title = updateTestimonialDto.Title,
                Status = updateTestimonialDto.Status,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Name = updateTestimonialDto.Name
            });
            return Ok("Başarıyla güncellendi...");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }
    }
}
