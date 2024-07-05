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
        [HttpGet("Product list with categories")]
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

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {

            _service.TAdd(new Product
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus
            });
            return Ok("Başarıyla ürün eklendi");
        }

        [HttpDelete]
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
               Description= updateProductDto.Description
            });
            return Ok("Başarıyla güncellendi...");
        }

        [HttpGet("Get product")]
        public IActionResult GetProduct(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }
    }
}
