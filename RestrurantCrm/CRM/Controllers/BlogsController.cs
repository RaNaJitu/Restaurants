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
    public class BlogsController : Controller
    {
        readonly CommonRepository<DefaultDbContext> repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());

        //Blogs/Index
        public ActionResult Index()
        {
            var data = repo.Query<BloggingDbModel>("select * from tbl_blogging order by CreatedOn desc");
            return View(data);
        }
        //Blogs/Add
        public ActionResult Add()
        {
            var data = repo.Add(new BloggingDbModel()
            {
                IsActive = false,
                CreatedOn = DateTime.Now,
                //ProjectCode = "PROJECT" + DateTime.Now.ToString("MMddyyyyHHmmss")

            });
            if (data != null)
            {
                return RedirectToAction("Save", "Blogs", new { @id = data.Id });
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return RedirectToAction("Index", "Blogs");
            }
        }
        //Blogs/Save
        public ActionResult Save(long ID)
        {
            var data = repo.Get<BloggingDbModel>(s => s.Id == ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Save(BloggingDbModel _data, long ID)
        {
            _data.CreatedOn = DateTime.Now;
            var data = repo.Save<BloggingDbModel>(_data, ID);
            if (data != null)
            {
                return RedirectToAction("Index", "Blogs");
            }
            else
            {
                ModelState.AddModelError("", "Somehting went wront. Please try again");
                return View();
            }

        }
        //Blogs/Delete
        public ActionResult Delete(long ID)
        {
            repo.Delete<BloggingDbModel>(ID);
            return RedirectToAction("Index", "Blogs");
        }
    }
}