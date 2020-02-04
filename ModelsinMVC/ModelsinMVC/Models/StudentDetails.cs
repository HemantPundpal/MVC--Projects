using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelsinMVC.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> StudentEmailList { get; set; }

        public StudentDetails()
        {
            this.StudentEmailList = new List<string>();
        }
    }
}