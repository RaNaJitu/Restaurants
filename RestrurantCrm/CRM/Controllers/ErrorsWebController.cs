using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class ErrorsWebController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Errors", "ErrorsWeb");
        }
        //ErrorsWeb/Errors
        public ActionResult Errors()
        {
            return View();
        }
        //ErrorsWeb/NotFound
        public ActionResult NotFound()
        {
            return View();
        }
    }
}