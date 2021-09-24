using Microsoft.AspNetCore.Mvc;

namespace serverside_aspnet.Controllers
{
    public class HomeController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}
