using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDto.CategoryDto;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategoryList() 
        {
            var result = _mapper.Map<List<ResultCategoryDto>>(_service.TGetListAll());
            return Ok(result);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount() => Ok(_service.TCategoryCount());
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount() => Ok(_service.TActiveCategoryCount());
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount() => Ok(_service.TPassiveCategoryCount());

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            
            _service.TAdd(new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                CategoryStatus = createCategoryDto.CategoryStatus
            });
            return Ok("Başarıyla kategori eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) 
        {
            var result=_service.TGetById(id);
            _service.TDelete(result);
            return Ok("Kategori başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _service.TUpdate(new Category
            {
                CategoryName = updateCategoryDto.CategoryName,
                CategoryStatus = updateCategoryDto.CategoryStatus,
                CategoryId=updateCategoryDto.CategoryId
            });
            return Ok("Başarıyla güncellendi...");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) 
        {
            var result= _service.TGetById(id);
            return Ok(result);
        }
    }
}
