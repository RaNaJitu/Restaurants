using Repo.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.App_Start
{
    public class CustomWebExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {

                var exceptionMessage = filterContext.Exception.Message;
                var stackTrace = filterContext.Exception.StackTrace;
                var controllerName = filterContext.RouteData.Values["controller"].ToString();
                var actionName = filterContext.RouteData.Values["action"].ToString();
                string original = "NA";
                Uri referrer = HttpContext.Current.Request.UrlReferrer;
                if (referrer != null)
                {
                    original = referrer.OriginalString.ToLower();
                }
                var source = controllerName + "/" + actionName + "#" + original;
                string Message = "Date :" + DateTime.Now.ToString() + ", Controller: " + controllerName + ", Action:" + actionName +
                                 "Error Message : " + exceptionMessage
                                + Environment.NewLine + "Stack Trace : " + stackTrace;

                //save this in a dabase
                (new HelperFactory()).LogtoSQL2(filterContext.Exception, source, Message);
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Errors/Index.cshtml"
                };
            }
        }
    }
}