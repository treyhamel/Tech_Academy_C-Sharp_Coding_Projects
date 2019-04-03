using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EF_CodeFirst_Exercise.Models;

namespace EF_CodeFirst_Exercise.DAL
{
    public class AcademyInitializer : System.Data.Entity.DropCreateDatabaseAlways<AcademyContext>
    {
        protected override void Seed(AcademyContext context)
        {
            var courses = new List<Course>
            {
                new Course{CourseID=1, CourseName="Web Development Course"},
                new Course{CourseID=2, CourseName="C# & .NET Framework Course"},
                new Course{CourseID=3, CourseName="Python Course"},
                new Course{CourseID=4, CourseName="Full Software Developer Course"}
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student{FirstName="Rusty", LastName="Shackleford",CourseID=3,EnrollmentDate=DateTime.Parse("08/10/2016"),PassFail=(PassFail)0},
                new Student{FirstName="Hank", LastName="Hill",CourseID=2,EnrollmentDate=DateTime.Parse("10/12/2016"),PassFail=(PassFail)0},
                new Student{FirstName="William", LastName="Feliciano",CourseID=1,EnrollmentDate=DateTime.Parse("11/05/2016"),PassFail=(PassFail)0},
                new Student{FirstName="Andrew", LastName="Edwards",CourseID=4,EnrollmentDate=DateTime.Parse("11/10/2016"),PassFail=(PassFail)1},
                new Student{FirstName="Keith", LastName="Gryffin",CourseID=2,EnrollmentDate=DateTime.Parse("12/25/2016"),PassFail=(PassFail)0},
                new Student{FirstName="Richard", LastName="Kelly",CourseID=1,EnrollmentDate=DateTime.Parse("02/12/2017")},
                new Student{FirstName="Johnathan", LastName="Robinson",CourseID=3,EnrollmentDate=DateTime.Parse("03/16/2017"),PassFail=(PassFail)0},
                new Student{FirstName="Caleb", LastName="McKinley",CourseID=4,EnrollmentDate=DateTime.Parse("05/17/2017"),PassFail=(PassFail)1},
                new Student{FirstName="James", LastName="Raynor",CourseID=3,EnrollmentDate=DateTime.Parse("05/18/2018"),PassFail=(PassFail)0},
                new Student{FirstName="Trey", LastName="Hamel",CourseID=2,EnrollmentDate=DateTime.Parse("02/16/2019")}
            };

            students.ForEach(c => context.Students.Add(c));
            context.SaveChanges();

        }
    }
}