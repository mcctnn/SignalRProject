using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult GetAllSliders()
        {
            var sliders = _sliderService.TGetListAll();
            return Ok(sliders);
        }

        [HttpGet("{id}")]
        public IActionResult GetSliderById(int id)
        {
            var slider = _sliderService.TGetById(id);
            return Ok(slider);
        }

        [HttpPost]
        public IActionResult AddSlider([FromBody] Slider slider)
        {
            _sliderService.TAdd(slider);
            return Ok("Slider added successfully");
        }

        [HttpPut]
        public IActionResult UpdateSlider([FromBody] Slider slider)
        {
            _sliderService.TUpdate(slider);
            return Ok("Slider updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var slider = _sliderService.TGetById(id);
            _sliderService.TDelete(slider);
            return Ok("Slider deleted successfully");
        }
    }
}
