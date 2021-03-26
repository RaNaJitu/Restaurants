using Newtonsoft.Json;
using Repo.Factories;
using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using FilterAttribute = System.Web.Mvc.FilterAttribute;
using IExceptionFilter = System.Web.Mvc.IExceptionFilter;

namespace Apis.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
    public class CustomApiExceptionFilter : ExceptionFilterAttribute
    {
        StandardResponseVM standardResponseVM = new StandardResponseVM();
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var actionName = ((System.Web.Http.Controllers.ReflectedHttpActionDescriptor)actionExecutedContext.ActionContext.ActionDescriptor).ActionName;
                var controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
                string original = "NA";
                Uri referrer = HttpContext.Current.Request.UrlReferrer;
                if (referrer != null)
                {
                    original = referrer.OriginalString.ToLower();
                }

                (new HelperFactory()).LogtoSQL2(actionExecutedContext.Exception, "Webapi=>CustomExceptionFilter", controllerName + "/" + actionName + "/" + original);
            }
            //We can log this exception message to the file or database.  
            standardResponseVM.errorMsg = "Exception Occurred";
            standardResponseVM.errorStatus = false;
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(standardResponseVM)),
                ReasonPhrase = standardResponseVM.errorMsg
            };
            actionExecutedContext.Response = response;
        }
    }
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