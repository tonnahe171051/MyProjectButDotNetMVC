using Microsoft.AspNetCore.Mvc;

namespace MyProjectButDotNetMVC.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }

}
