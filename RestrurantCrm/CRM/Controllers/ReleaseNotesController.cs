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
    public class ReleaseNotesController : Controller
    {
        readonly CommonRepository<DefaultDbContext> repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());

        //ReleaseNotes/Index
        public ActionResult Index()
        {
            var data = repo.Query<ReleaseNotesModel>("select * from tbl_release_notes order by created_on desc");
            return View(data);
        }
        //ReleaseNotes/Releases
        public ActionResult Releases()
        {
            var data = repo.Query<ReleaseNotesModel>("select * from tbl_release_notes order by created_on desc");
            return View(data);
        }
        //ReleaseNotes/Add
        public ActionResult Add()
        {
            var data = repo.Add(new ReleaseNotesModel()
            {
                is_active = false,
                created_on = DateTime.Now
            });
            if (data != null)
            {
                return RedirectToAction("Save", "ReleaseNotes", new { @id = data.Id });
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return RedirectToAction("Index", "ReleaseNotes");
            }
        }
        //ReleaseNotes/Save
        public ActionResult Save(long ID)
        {
            var data = repo.Get<ReleaseNotesModel>(s => s.Id == ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Save(ReleaseNotesModel _data, long ID)
        {
            _data.created_on = DateTime.Now;
            var data = repo.Save<ReleaseNotesModel>(_data, ID);
            if (data != null)
            {
                return RedirectToAction("Index", "ReleaseNotes");
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return View();
            }

        }
        //ReleaseNotes/Delete
        public ActionResult Delete(long ID)
        {
            repo.Delete<ReleaseNotesModel>(ID);
            return RedirectToAction("Index", "ReleaseNotes");
        }
    }
}