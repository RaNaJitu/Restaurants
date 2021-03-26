using Repo.DbContexts;
using Repo.Factories;
using Repo.Models;
using Repo.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apis.Controllers
{
    public class BlogController : ApiController
    {
        private readonly CommonRepository<DefaultDbContext> _repo = new CommonRepository<DefaultDbContext>(new DefaultDbContext());
        [Authorize]
        [HttpGet]
        [Route("api/Blog/Blogs")]
        public IHttpActionResult Blogs()
        {
            BlogVM _response= new BlogVM();
            try
            {
                List<BloggingDbModel> data = new List<BloggingDbModel>();
                data = _repo.Query<BloggingDbModel>("select * from tbl_blogging where IsActive=1 order by CreatedOn desc").ToList();
                _response.Blog = data;
                _response.errorMsg = "SUCCESS";
                _response.errorStatus = true;
            }
            catch (Exception ex)
            {
                _response.errorMsg = "Something went wrong";
                _response.errorStatus = false;
                new HelperFactory().LogtoSQL2(ex, "BlogController=>Blogs", "");
            }
            return Ok(_response);
        }
    }
}
