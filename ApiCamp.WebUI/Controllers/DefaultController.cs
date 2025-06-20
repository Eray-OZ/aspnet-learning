using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
