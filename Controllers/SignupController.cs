using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.DbAccess;
using MongoDB.Driver;


namespace WebApplication1.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel? user)
        {
             string name = user!=null?( user.Firstname + " " + user.Lastname):"";

            Console.WriteLine(name);
            if(user!=null)
            {
                DbMethods db = new DbMethods();
                var userExist = await db.FindUser(user);
                if (userExist)
                {
                    ViewBag.success=false;
                    ViewBag.message = "User Already Exists";
                    return View();
                }
                else
                {
                    Console.WriteLine("line 33 sgncntr"+userExist);
                    ViewBag.success = true;
                    db.SaveUser(user) ;
                    ViewBag.message = "User Saved Successfully";
                    return View();
                }
            }
            return View();

        }
    }
}
