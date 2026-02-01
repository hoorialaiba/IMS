using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Udash()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
