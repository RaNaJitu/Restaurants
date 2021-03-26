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
    public class SmsGatewaysController : Controller
    {
        readonly CommonRepository<DefaultDbContext> repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());

        //SmsGateways/Index
        public ActionResult Index()
        {
            var data = repo.Query<SmsConfigModel>("select * from tbl_sms_config order by CreatedOn desc");
            return View(data);
        }
        //SmsGateways/Add
        public ActionResult Add()
        {
            var data = repo.Add(new SmsConfigModel()
            {
                IsActive = false,
                CreatedOn = DateTime.Now
            });
            if (data != null)
            {
                return RedirectToAction("Save", "SmsGateways", new { @id = data.Id });
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return RedirectToAction("Index", "SmsGateways");
            }
        }
        //SmsGateways/Save
        public ActionResult Save(long ID)
        {
            var data = repo.Get<SmsConfigModel>(s => s.Id == ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Save(SmsConfigModel _data, long ID)
        {
            _data.CreatedOn = DateTime.Now;
            var data = repo.Save<SmsConfigModel>(_data, ID);
            if (data != null)
            {
                return RedirectToAction("Index", "SmsGateways");
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return View();
            }

        }
        //SmsGateways/Delete
        public ActionResult Delete(long ID)
        {
            repo.Delete<SmsConfigModel>(ID);
            return RedirectToAction("Index", "SmsGateways");
        }
    }
}