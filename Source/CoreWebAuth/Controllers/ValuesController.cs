using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebAuth.Common;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAuth.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : AuthController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //Dictionary<string, string> dic = CommonHelper.paraURLParm(HttpContext.Request.QueryString.Value);
            //return new string[] { HttpContext.Request.QueryString.Value };
          
            return new string[] { "value1-get", "value2-get" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            ///return HttpContext.ToString();
            return "value";
        }

        //// POST api/values
        //[HttpPost]
        //public string P([FromBody]string value)
        //{
        //    return value;
        //}

        [HttpPost]
        public string P()
        {
            return "postmethod";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
