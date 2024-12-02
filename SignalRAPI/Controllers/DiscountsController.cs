using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDto.CategoryDto;
using SignalRDto.DiscountDto;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly IMapper _mapper;
        public DiscountsController(IDiscountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDiscountList()
        {
            var result = _mapper.Map<List<ResultDiscountDto>>(_service.TGetListAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {

            _service.TAdd(new Discount
            {
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl,
                Title = createDiscountDto.Title,
            });
            return Ok("Başarıyla discount eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var result = _service.TGetById(id);
            _service.TDelete(result);
            return Ok("Discount başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _service.TUpdate(new Discount
            {
                DiscountId = updateDiscountDto.DiscountId,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Title = updateDiscountDto.Title
            });
            return Ok("Başarıyla güncellendi...");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }
    }
}
