using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;
using SignalRAPI.Models;
using SignalRBusiness.Abstract;
using SignalRDataAccess.Concrete;
using SignalRDto.BasketDto;

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

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context= new SignalRContext();
            _basketService.TAdd(new Basket
            {
                ProductId = createBasketDto.ProductId,
                Count =1,
                MenuTableId=2,
                Price=context.Products.Where(x=>x.ProductId==createBasketDto.ProductId).Select(y=>y.Price).FirstOrDefault(),
                TotalPrice=0
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id) 
        { 
            var value=_basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki seçili ürün silindi");
        }
    }
}
