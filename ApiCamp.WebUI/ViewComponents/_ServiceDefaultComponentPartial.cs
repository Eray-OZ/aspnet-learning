using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebUI.ViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
