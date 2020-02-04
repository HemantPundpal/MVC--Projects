using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ModelsinMVC.Models
{
    public class StudentView
    {
        public List<Student> studentList { get; set; }
        public List<StudentEmail> studentEmailList { get; set; }
    }
}