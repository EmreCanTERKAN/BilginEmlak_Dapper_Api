﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_UI.ViewCompanents.HomePage
{
    public class _DefaultProductListExporeCitiesComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultProductListExporeCitiesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44304/api/PopularLocations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                // jsonu yakalayıp normal formata dönüştürüyor. 
                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                return View(values);
            }
            return View();
            
        }
    }
}
