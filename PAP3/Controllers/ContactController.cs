using Microsoft.AspNetCore.Mvc;

namespace PAP3.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
