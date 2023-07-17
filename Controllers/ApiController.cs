using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApplication1.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        
        // POST api/<ApiController>
        [HttpPost]
        [Route("api/ApiController/login")]
        public HttpResponseMessage Login(UserModel request)
        {
            var result = new
            {
                Success = true,
                StatusCode = 200,
                data = request
            };
            Console.WriteLine(result);
            return new HttpResponseMessage(HttpStatusCode.OK);
      
           





        } 

    }
}
