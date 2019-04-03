using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirst_Exercise.Models
{

    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}