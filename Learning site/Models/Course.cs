using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning_site.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string InstructorId { get; set; }
        public  virtual ApplicationUser instructor { get; set; }

    }
}