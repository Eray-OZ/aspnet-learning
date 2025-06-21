using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
