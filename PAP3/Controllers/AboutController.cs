using Microsoft.AspNetCore.Mvc;

namespace PAP3.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
