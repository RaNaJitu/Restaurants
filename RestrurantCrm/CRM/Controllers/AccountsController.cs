using CRM.App_Start;
using Repo.DbContexts;
using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRM.Controllers
{
    [CustomWebExceptionFilter]
    public class AccountsController : Controller
    {
        public ActionResult Index()
        {

            return Redirect("~/accounts/Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (DefaultDbContext context = new DefaultDbContext())
            {
                bool IsValidUser = context.CredentialDbModels.Any(user => user.Username.ToLower() ==
                     model.UserName.ToLower() && user.Password == model.UserPassword);
                if (IsValidUser)
                {
                    bool isChecked = false;
                    if (model.customCheck1 == "on")
                    {
                        isChecked = true;
                    }
                    FormsAuthentication.SetAuthCookie(model.UserName, isChecked);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}