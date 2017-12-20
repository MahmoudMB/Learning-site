using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learning_site.Models
{
    public class EnrolledCourse
    {

        public int Id { get; set; }
      
        public int CourseId { get; set; }
        public virtual Course course { get; set; }
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }
        public virtual Assignment assignment { get; set; }


    }



}