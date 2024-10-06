using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewCompanents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        //apiden consume işlemi için gerekli komutlar
        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //bir client oluşturup request edilecektir.
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync("https://localhost:44304/api/WhoWeAreDetails");
            var responseMessage2 = await client.GetAsync("https://localhost:44304/api/Services");
            if (responseMessage.IsSuccessStatusCode & responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);
                ViewBag.Title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.subTitle = value.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.desription1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.desription2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);

            }
            return View();
        }
    }
}
