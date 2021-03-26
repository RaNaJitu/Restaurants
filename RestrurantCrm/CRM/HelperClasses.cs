using Repo.DbContexts;
using Repo.Factories;
using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM
{
    public static class HelperClasses
    {
       
        public static SelectList PeopleName()
        {
            List<SelectListItem> _objlist = new List<SelectListItem>();
           
            try
            {
                DefaultDbContext db = new DefaultDbContext();
                var _list = db.Database.SqlQuery<PeopleDbModel>("select * from tbl_people_master where IsActive=1").ToList();
                foreach (var item in _list)
                {
                    _objlist.Add(new SelectListItem { Selected = false, Text = item.Fname, Value = item.Code });
                }
            }
            catch (Exception ex)
            {
                new HelperFactory().LogtoSQL2(ex, "HelperFactory=>GetProject", "");
            }
            return new SelectList(_objlist, "Value", "Text");
        }
    }
}