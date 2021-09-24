using Microsoft.AspNetCore.Mvc;

namespace serverside_aspnet.Controllers
{
    public class DepartamentoController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}
