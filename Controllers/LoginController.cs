using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DbAccess;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor conxt;
        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            conxt = httpContextAccessor;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {


            /* if(email!=null && password!=null) {

                     DbMethods db = new DbMethods();
                     var results = await db.FindUserByEmail(email, password);  *//*await*//*
               Console.WriteLine(results);

                     if (results)
                     {
                         HttpContext.Session.SetString("User", email);

                         if(HttpContext.Session.IsAvailable && HttpContext.Session.GetString("User").Any())
                         {
                             return RedirectToAction("Index", "Main");
                         }

                     }
                     else
                     {
                         ViewBag.success = false;
                         ViewBag.message = "Invalid Credentials";
                         return View();
                     }

             }
                 ViewBag.success = false;
                 ViewBag.message = "Login Failed";
                 return View();

             }
             catch (Exception ex) {
                 ViewBag.message = ex.Message;
                 return View();
             }
 */

            if (email != null && password != null)
            {
                try
                {
                    DbMethods db = new DbMethods();


                    var result = await db.FindUserByEmail(email, password);
                    if (result)
                    {
                        Console.WriteLine(result + " pop");

                        HttpContext.Session.SetString("User", email);
                        Console.WriteLine(HttpContext.Session.GetString("User"));
                        if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("User").Any())
                        {
                            return RedirectToAction("Index", "Main");
                        }
                        else
                        {
                            ViewBag.message = "Login Failed!!";
                        }
                    }
                    else
                    {
                        ViewBag.success = false;
                        ViewBag.message = "Invalid Credentials";
                        return View();
                    }

                }
                catch (Exception e)
                {
                    return View(e);
                }
            }

            ViewBag.success = false;
            ViewBag.message = "Both Email and Password are Required!!";
            return View();
        }
    }

            
    }
