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
    public class AddressController : Controller
    {
        readonly CommonRepository<DefaultDbContext> repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());

        //Address/Index
        public ActionResult Index()
        {
            var data = repo.Query<AddressDbModel>("select * from tbl_address order by CreatedOn desc");
            return View(data);
        }
        //Address/Add
        public ActionResult Add()
        {
            var data = repo.Add(new AddressDbModel()
            {
                IsActive = false,
                CreatedOn = DateTime.Now,
                Code = "Address" + DateTime.Now.ToString("MMddyyyyHHmmss")

            });
            if (data != null)
            {
                return RedirectToAction("Save", "Address", new { @id = data.Id });
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return RedirectToAction("Index", "Address");
            }
        }
        //Address/Save
        public ActionResult Save(long ID)
        {
            var data = repo.Get<AddressDbModel>(s => s.Id == ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Save(AddressDbModel _data, long ID)
        {
            _data.CreatedOn = DateTime.Now;
            var data = repo.Save<AddressDbModel>(_data, ID);
            if (data != null)
            {
                return RedirectToAction("Index", "Address");
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return View();
            }

        }
        //Address/Delete
        public ActionResult Delete(long ID)
        {
            repo.Delete<AddressDbModel>(ID);
            return RedirectToAction("Index", "Address");
        }
    }
}