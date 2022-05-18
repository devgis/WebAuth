// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Mvc;

namespace CoreWebAuth.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Error:"+id;
        }
    }
}
