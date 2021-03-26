using Repo.DbContexts;
using Repo.Models;
using Repo.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class EmailTemplatesController : Controller
    {
        readonly CommonRepository<DefaultDbContext> repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());

        //EmailTemplates/Index
        public ActionResult Index()
        {
            var data = repo.Query<EmailTemplateMaster>("select * from tbl_email_template order by CreatedOn desc");
            return View(data);
        }
        //EmailTemplates/Add
        public ActionResult Add()
        {
            var data = repo.Add(new EmailTemplateMaster()
            {
                IsActive = false,
                CreatedOn = DateTime.Now,
                TemplateCode = "MAIL" + DateTime.Now.ToString("MMddyyyyHHmmss")
            });
            if (data != null)
            {
                return RedirectToAction("Save", "EmailTemplates", new { @id = data.Id });
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return RedirectToAction("Index", "EmailTemplates");
            }
        }
        //EmailTemplates/Save
        public ActionResult Save(long ID)
        {
            var data = repo.Get<EmailTemplateMaster>(s => s.Id == ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Save(EmailTemplateMaster _data, long ID)
        {
            _data.CreatedOn = DateTime.Now;
            var data = repo.Save<EmailTemplateMaster>(_data, ID);
            if (data != null)
            {
                return RedirectToAction("Index", "EmailTemplates");
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return View();
            }

        }
        //EmailTemplates/Delete
        public ActionResult Delete(long ID)
        {
            repo.Delete<EmailTemplateMaster>(ID);
            return RedirectToAction("Index", "EmailTemplates");
        }
        //EmailTemplates/Preview
        public ActionResult Preview(long ID)
        {
            var _data = repo.Get<EmailTemplateMaster>(s => s.Id == ID);
            if (_data != null)
            {
                ViewBag.Content = _data.TemplateContent;
            }
            else
            {
                ViewBag.Content = "<h2>No Data Available</h2>";
            }
            return View(_data);
        }
    }
}