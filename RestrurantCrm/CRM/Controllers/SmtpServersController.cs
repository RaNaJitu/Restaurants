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
    public class SmtpServersController : Controller
    {
        readonly CommonRepository<DefaultDbContext> repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());

        //SmtpServers/Index
        public ActionResult Index()
        {
            var data = repo.Query<MailConfigModel>("select * from tbl_mail_config order by CreatedOn desc");
            return View(data);
        }
        //SmtpServers/Add
        public ActionResult Add()
        {
            var data = repo.Add(new MailConfigModel()
            {
                IsActive = false,
                CreatedOn = DateTime.Now
            });
            if (data != null)
            {
                return RedirectToAction("Save", "SmtpServers", new { @id = data.Id });
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return RedirectToAction("Index", "SmtpServers");
            }
        }
        //SmtpServers/Save
        public ActionResult Save(long ID)
        {
            var data = repo.Get<MailConfigModel>(s => s.Id == ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Save(MailConfigModel _data, long ID)
        {
            _data.CreatedOn = DateTime.Now;
            var data = repo.Save<MailConfigModel>(_data, ID);
            if (data != null)
            {
                return RedirectToAction("Index", "SmtpServers");
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return View();
            }
        }
        //SmtpServers/Delete
        public ActionResult Delete(long ID)
        {
            repo.Delete<MailConfigModel>(ID);
            return RedirectToAction("Index", "SmtpServers");
        }
    }
}