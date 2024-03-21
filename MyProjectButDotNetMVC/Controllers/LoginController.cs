using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProjectButDotNetMVC.DataAccess.Repository;
using MyProjectButDotNetMVC.Models;

namespace MyProjectButDotNetMVC.Controllers
{
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        
        public IActionResult Index([FromForm] string email, [FromForm] string password)
        {
            try
            {
                IMemberRepository memberRepository = new MemberRepository();
                Member loginMember = memberRepository.Login(email, password);

                if (loginMember != null)
                {
                    HttpContext.Session.SetInt32("MemberId", loginMember.MemberId);
                }

                return RedirectToAction("Index", "Members");
            }
            catch (Exception ex)
            {
                ViewBag.Email = email;
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public IActionResult UserAccessDenied()
        {
            return View();
        }
    }

}
