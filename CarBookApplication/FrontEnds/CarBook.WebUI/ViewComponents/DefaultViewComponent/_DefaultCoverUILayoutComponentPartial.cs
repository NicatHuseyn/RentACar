using CarBook.Dto.BannerDtos;
using CarBook.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponent
{
    public class _DefaultCoverUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult>  InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7277/api/Banners");
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
