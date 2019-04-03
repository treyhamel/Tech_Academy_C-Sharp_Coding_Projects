using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EF_CodeFirst_Exercise.Models;
using System.Runtime.Remoting.Contexts;

namespace EF_CodeFirst_Exercise.DAL
{
    public class AcademyContext : DbContext
    {
        public AcademyContext() : base("AcademyContext")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}