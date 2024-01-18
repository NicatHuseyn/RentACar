using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponent
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
