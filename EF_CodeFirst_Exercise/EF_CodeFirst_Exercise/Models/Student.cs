using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirst_Exercise.Models
{
    public enum PassFail
    {
        Pass, Fail
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public PassFail? PassFail { get; set; }

        public virtual Course Course { get; set; }
    }
}