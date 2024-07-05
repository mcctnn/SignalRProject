using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDto.AboutDto;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _service;

        public AboutController(IAboutService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var result = _service.TGetListAll();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
            };
            _service.TAdd(about);
            return Ok("Hakkımda alanı başarıyla eklendi...");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id) 
        {
            var result=_service.TGetById(id);
            _service.TDelete(result);
            return Ok("Hakkımda alanı silindi...");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId = updateAboutDto.AboutId,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl,
            };
            _service.TUpdate(about);
            return Ok("Hakkımda alanı başarıyla güncellendi...");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id) 
        { 
            var result= _service.TGetById(id);
            return Ok(result);
        }

    }
}
