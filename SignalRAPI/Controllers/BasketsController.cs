using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusiness.Abstract;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var result = _basketService.TGetBasketByMenuTableNumber(id);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
