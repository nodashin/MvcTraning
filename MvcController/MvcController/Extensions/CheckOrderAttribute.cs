using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcController.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple =true)]
    public class CheckOrderAttribute : ActionFilterAttribute
    {
        //アクションの実行前に実行
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(string.Format("<p>OnActionExecuting{0}", this.Order));
            if(this.Order == 2)
            {
                throw new Exception("例外発生");
            }
        }

        //アクションの実行後に実行
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(string.Format("<p>OnActionExecuted{0}", this.Order));
            filterContext.ExceptionHandled = true;
        }

        //ActionResultの実行前に実行
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(string.Format("<p>OnResultExecuting{0}", this.Order));
        }

        //ActionResultの実行後に実行
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(string.Format("<p>OnResultExecuted{0}", this.Order));
        }
    }
}