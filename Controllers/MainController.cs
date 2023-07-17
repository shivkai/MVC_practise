using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
  
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                Console.WriteLine("mm " + HttpContext.Session.ToString());
                if(HttpContext.Session.GetString("User").Any())
                {

                     return View();
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");

            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Logout()
        {
            Console.WriteLine("Wola");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
