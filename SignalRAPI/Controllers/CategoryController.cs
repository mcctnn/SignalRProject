﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDto.CategoryDto;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService service, IMapper mapper)
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

        [HttpGet("Get category")]
        public IActionResult GetCategory(int id) 
        {
            var result= _service.TGetById(id);
            return Ok(result);
        }
    }
}
