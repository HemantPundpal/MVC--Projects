using System;
using System.Data.Entity;

namespace BusinessLayer
{
    public class StudentContext : DbContext
    {
        //public StudentContext()
        //{
        //    Database.SetInitializer<StudentContext>(null);
        //}
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentEmail> StudentEmails { get; set; }
    }
}
