using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDataAccess.Concrete;
using SignalRDto.CategoryDto;
using SignalRDto.ProductDto;
using System.Collections.Generic;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            var result = _mapper.Map<List<ResultProductDto>>(_service.TGetListAll());
            return Ok(result);
        }
        [HttpGet("ProductListWithCategories")]
        public IActionResult ProductListWithCategories() 
        {
            var context = new SignalRContext();
            var value = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
                
            });
            return Ok(value.ToList());
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount() => Ok(_service.TProductCount());
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByCategoryNameBurger() => Ok(_service.TProductCountByCategoryNameBurger());
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByCategoryNameDrink() => Ok(_service.TProductCountByCategoryNameDrink());

        [HttpGet("ProductPriceAverage")]
        public IActionResult ProductPriceAvg()=>Ok(_service.TProductPriceAvg());
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice() => Ok(_service.TProductNameByMaxPrice());
        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice() => Ok(_service.TProductNameByMinPrice());

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {

            _service.TAdd(new Product
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus,
                CategoryId=createProductDto.CategoryId
            });
            return Ok("Başarıyla ürün eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _service.TGetById(id);
            _service.TDelete(result);
            return Ok("Ürün başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _service.TUpdate(new Product
            {
               ProductId = updateProductDto.ProductId,
               ProductName = updateProductDto.ProductName,
               ProductStatus = updateProductDto.ProductStatus,
               Price= updateProductDto.Price,
               ImageUrl= updateProductDto.ImageUrl,
               Description= updateProductDto.Description,
               CategoryId = updateProductDto.CategoryId
            });
            return Ok("Başarıyla güncellendi...");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }
    }
}
