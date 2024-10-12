using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{

    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyAdvertsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // apiyi consume işlemi yapıyoruz...
        public async Task<IActionResult> Index(int id)
        {
            // şimdilik manuel
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44304/api/Products/ProductAdvertListByEmployeeId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
