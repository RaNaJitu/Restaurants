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
    public class SenderMasterController : Controller
    {
        readonly CommonRepository<DefaultDbContext> repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());

        //SenderMaster/Index
        public ActionResult Index()
        {
            var data = repo.Query<SenderMasterModel>("select * from tbl_sender_master order by CreatedOn desc");
            return View(data);
        }
        //SenderMaster/Add
        public ActionResult Add()
        {
            var data = repo.Add(new SenderMasterModel()
            {
                IsActive = false,
                CreatedOn = DateTime.Now
            });
            if (data != null)
            {
                return RedirectToAction("Save", "SenderMaster", new { @id = data.Id });
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return RedirectToAction("Index", "SenderMaster");
            }
        }
        //SenderMaster/Save
        public ActionResult Save(long ID)
        {
            var data = repo.Get<SenderMasterModel>(s => s.Id == ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Save(SenderMasterModel _data, long ID)
        {
            _data.CreatedOn = DateTime.Now;
            var data = repo.Save<SenderMasterModel>(_data, ID);
            if (data != null)
            {
                return RedirectToAction("Index", "SenderMaster");
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return View();
            }
        }
        //SenderMaster/Delete
        public ActionResult Delete(long ID)
        {
            repo.Delete<SenderMasterModel>(ID);
            return RedirectToAction("Index", "SenderMaster");
        }
    }
}