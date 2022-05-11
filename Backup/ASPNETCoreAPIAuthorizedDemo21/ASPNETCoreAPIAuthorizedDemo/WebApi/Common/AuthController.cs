using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Common
{
    public class AuthController: Controller
    {
        public const string uName = "u";
        public const string pName = "pwd";
        public const string aName = "au";

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool bAuth = false;

            //读取cookie
            string au = context.HttpContext.Request.Headers["au"];
            if (string.IsNullOrEmpty(au))
            {
                string u = string.Empty;
                string pwd = string.Empty;
                //用户密码校验
                if ("GET".Equals(context.HttpContext.Request.Method.ToUpper()))
                {
                    if (context.HttpContext.Request.Query.ContainsKey(uName))
                    {
                        u = context.HttpContext.Request.Query[uName];
                    }
                    if (context.HttpContext.Request.Query.ContainsKey(pName))
                    {
                        pwd = context.HttpContext.Request.Query[pName];
                    }
                    
                }
                else if ("POST".Equals(context.HttpContext.Request.Method.ToUpper()))
                {
                    if (context.HttpContext.Request.Form.ContainsKey(uName))
                    {
                        u = context.HttpContext.Request.Form[uName];
                    }
                    if (context.HttpContext.Request.Form.ContainsKey(pName))
                    {
                        pwd = context.HttpContext.Request.Form[pName];
                    }
                }

                if (string.IsNullOrEmpty(CheckUser(u,pwd)))
                {
                    go401(context);
                }
                else
                {
                    bAuth = true;
                }
            }
            else
            {
                //cookie验证

                //假设非空就是验证通过
                if ("checkok".Equals(au))
                {
                    bAuth = true;
                }
                else
                {
                    go401(context);
                }
            }
            if (bAuth)
            {
                base.OnActionExecuting(context);
            }
        }

        /// <summary>
        /// 校验未通过
        /// </summary>
        /// <param name="context"></param>
        private void go401(ActionExecutingContext context)
        {
            this.Unauthorized();
            context.HttpContext.Response.StatusCode = 401;
            //this.Forbid();
            //context.HttpContext.Response.Redirect("/Error/401");
            //this.NoContent();
            //context.Result = new EmptyResult();
            //JsonResult rsult = new JsonResult(new ApiResult {code=401,errmessge= "Unauthorized Operation.",data ="" });
            //rsult.Content= "401 Unauthorized Operation.";
            context.Result = new JsonResult(new ApiResult { code = 401, errmessge = "Unauthorized Operation.", data = "" }); ;
            //context.HttpContext.Response.End;
            //BinaryWriter bw = new BinaryWriter(context.HttpContext.Response.Body);
            //string str = "401 Not Auth";
            //bw.Write(str);
            //base.Dispose();

        }

        public static string CheckUser(string u, string pwd)
        {
            if (string.IsNullOrEmpty(u))
            {
                return string.Empty;
            }
            if ("1".Equals(u) && "123".Equals(pwd))
            {
                return "checkok";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
