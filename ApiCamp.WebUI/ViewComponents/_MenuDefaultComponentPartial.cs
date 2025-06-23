using ApiCamp.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiCamp.WebUI.ViewComponents
{
    public class _MenuDefaultComponentPartial : ViewComponent
    {


        private readonly IHttpClientFactory _httpClientFactory;


        public _MenuDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7060/api/Products/ProductListWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);

                return View(values);
            }

            return View();
        }

    }
}
