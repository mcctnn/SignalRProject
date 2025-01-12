using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRAPI.Models;
using SignalRBusiness.Abstract;
using SignalRDataAccess.Concrete;

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

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context=new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableId == id).Select(z => new ResultBasketListWithProducts
            {
                BasketId=z.BasketId,
                Count=z.Count,
                MenuTableId=z.MenuTableId,
                Price=z.Price,
                ProductId=z.ProductId,
                TotalPrice=z.TotalPrice,
                ProductName=z.Product.ProductName
            }).ToList();
            return Ok(values);
        }
    }
}
