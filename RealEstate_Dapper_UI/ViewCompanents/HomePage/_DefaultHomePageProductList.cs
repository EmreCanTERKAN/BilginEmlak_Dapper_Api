using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewCompanents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        // apiden consume işlemi yapabilmek için verileri kullanabileceğimiz Dependency injection ile bir değişken tanımladık.
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // isteği atacak bir istemci tanımladık..
            var client = _httpClientFactory.CreateClient();
            // istemciyle birlikte Get,Post,put gibi yapılacak işlemi bir değişkene atıyoruz.
            // bu projeyi canlıya taşıdığımız vakit aşağıdaki localhost yerine isteği atacağımız adresse gitmesi gerekmektedir.
            var responseMessage = await client.GetAsync("https://localhost:44304/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                // Gelen mesajı string formatında oku
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //json dosyasını karşılayabilmemiz için tablo formatına dönüştürmemiz gerekiyor.
                //json değerini resultproductdtos nesnesinden bir listeye çeviriyor.
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>> (jsonData);
                return View(values);
            }
            return View();
        }
    }
}
