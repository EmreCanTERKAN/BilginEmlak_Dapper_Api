﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class WhoWeAreController : Controller
    {

            private readonly IHttpClientFactory _httpClientFactory;

            public WhoWeAreController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            // apiyi consume işlemi yapıyoruz...
            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44304/api/WhoWeAreDetails");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                    return View(values);

                }
                return View();
            }

            [HttpGet]
            public IActionResult CreateWhoWeAreDetail()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
            {
                var client = _httpClientFactory.CreateClient();
                //Ekleme,Güncelleme işlemleri serialize, Listeleme ve Idye göre getirme Desiriliaze 
                var jsonData = JsonConvert.SerializeObject(createWhoWeAreDetailDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:44304/api/WhoWeAreDetails", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"https://localhost:44304/api/WhoWeAreDetails/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public async Task<IActionResult> UpdateWhoWeAreDetail(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMesage = await client.GetAsync($"https://localhost:44304/api/WhoWeAreDetails/{id}");
                if (responseMesage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMesage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateWhoWeAreDetailDto>(jsonData);
                    return View(values);

                }
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateWhoWeAreDetailDto);
                // apiye göndereceğimiz için stringcontent formatına döndürdük.
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:44304/api/WhoWeAreDetails/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
}
