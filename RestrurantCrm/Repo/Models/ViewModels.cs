using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string customCheck1 { get; set; }
    }
    public class TestViewModel
    {
        public long id { get; set; }
        public string name { get; set; }
    }
    public class StandardResponseVM
    {
        public string errorMsg { get; set; }
        public bool errorStatus { get; set; }
    }
    public class BlogVM
    {
        public string errorMsg { get; set; }
        public bool errorStatus { get; set; }
        public List<BloggingDbModel> Blog { get; set; }
    }
}
