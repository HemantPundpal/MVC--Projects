using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsinMVC.Models
{
    [Table("Emails")]
    public class StudentEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; }
    }
}