using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class PresalesController : Controller
    {
        // GET: Presales
        public ActionResult WhishList()
        {
            return View();
        }
        public ActionResult Enquiries()
        {
            return View();
        }
    }
}