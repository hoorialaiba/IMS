using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Main()
        {
            return View();
        }
    }
}
