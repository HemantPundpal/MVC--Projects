using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusinessLayer
{
    [Table("Emails")]
    public class StudentEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; }
    }
}
