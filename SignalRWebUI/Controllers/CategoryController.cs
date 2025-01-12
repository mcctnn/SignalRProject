﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7180/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            categoryDto.CategoryStatus =true;   
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(categoryDto);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7180/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7180/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client= _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7180/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
		}
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7180/api/Categories/", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
