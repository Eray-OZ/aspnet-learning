using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebUI.ViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
