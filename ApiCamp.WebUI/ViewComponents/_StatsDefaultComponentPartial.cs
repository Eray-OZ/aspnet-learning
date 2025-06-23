using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebUI.ViewComponents
{
    public class _StatsDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
