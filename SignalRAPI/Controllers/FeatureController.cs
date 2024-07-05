using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDto.CategoryDto;
using SignalRDto.FeatureDto;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _service;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFeatureList()
        {
            var result = _mapper.Map<List<ResultFeatureDto>>(_service.TGetListAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {

            _service.TAdd(new Feature
            {
                Description1 = createFeatureDto.Description1,
                Description2 = createFeatureDto.Description2,
                Description3 = createFeatureDto.Description3,
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3
            });
            return Ok("Başarıyla Feature eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var result = _service.TGetById(id);
            _service.TDelete(result);
            return Ok("Kategori başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _service.TUpdate(new Feature
            {
                FeatureId = updateFeatureDto.FeatureId,
                Description1 = updateFeatureDto.Description1,
                Description2 = updateFeatureDto.Description2,
                Description3 = updateFeatureDto.Description3,
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3
            });
            return Ok("Başarıyla güncellendi...");
        }

        [HttpGet("Get feature")]
        public IActionResult GetCategory(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }
    }
}
