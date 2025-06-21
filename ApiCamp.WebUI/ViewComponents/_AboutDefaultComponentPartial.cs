using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebUI.ViewComponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
