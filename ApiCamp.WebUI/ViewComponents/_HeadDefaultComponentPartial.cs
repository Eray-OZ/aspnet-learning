using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebUI.ViewComponents
{
    public class _HeadDefaultComponentPartial: ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
