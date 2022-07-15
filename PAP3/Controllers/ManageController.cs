using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PAP3.Controllers
{
    [Authorize(Roles = "Administrator,Manager")]
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
