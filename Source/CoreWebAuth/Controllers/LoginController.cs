// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using CoreWebAuth.Common;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAuth.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        // GET api/values/5
        [HttpPost]
        public string Get()
        {
            //HttpContext.Response.ContentType="application/json; charset=utf-8";
            string u = string.Empty;
            string pwd = string.Empty;
            if (HttpContext.Request.Form.ContainsKey(AuthController.uName))
            {
                u = HttpContext.Request.Form[AuthController.uName];
            }
            if (HttpContext.Request.Form.ContainsKey(AuthController.pName))
            {
                pwd = HttpContext.Request.Form[AuthController.pName];
            }

            string au = AuthController.CheckUser(u, pwd);
            if (string.IsNullOrEmpty(au))
            {
                return "{\"rs\":false,\"au\":\"" + au + "\"}";
            }
            else
            {
                return "{\"rs\":true,\"au\":\"" + au + "\"}";
            }
        }
    }
}
