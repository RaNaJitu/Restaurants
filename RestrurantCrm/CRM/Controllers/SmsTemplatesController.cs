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
    public class SmsTemplatesController : Controller
    {
        readonly CommonRepository<DefaultDbContext> repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());

        //SmsTemplates/Index
        public ActionResult Index()
        {
            var data = repo.Query<SmsTemplateModel>("select * from tbl_sms_template order by CreatedOn desc");
            return View(data);
        }
        //SmsTemplates/Add
        public ActionResult Add()
        {
            var data = repo.Add(new SmsTemplateModel()
            {
                IsActive = false,
                CreatedOn = DateTime.Now,
                TemplateCode = "SMS" + DateTime.Now.ToString("MMddyyyyHHmmss")

            });
            if (data != null)
            {
                return RedirectToAction("Save", "SmsTemplates", new { @id = data.Id });
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return RedirectToAction("Index", "SmsTemplates");
            }
        }
        //SmsTemplates/Save
        public ActionResult Save(long ID)
        {
            var data = repo.Get<SmsTemplateModel>(s => s.Id == ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Save(SmsTemplateModel _data, long ID)
        {
            _data.CreatedOn = DateTime.Now;
            var data = repo.Save<SmsTemplateModel>(_data, ID);
            if (data != null)
            {
                return RedirectToAction("Index", "SmsTemplates");
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return View();
            }

        }
        //SmsTemplates/Delete
        public ActionResult Delete(long ID)
        {
            repo.Delete<SmsTemplateModel>(ID);
            return RedirectToAction("Index", "SmsTemplates");
        }
    }
}