using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLayer;

namespace BusinessObjectsasModelsinMVC.Models
{
    public class StudentsDetailsViewModel : IStudentDetails
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Student Email")]
        [Required]
        public List<string> studentEmails { get; set; }

        public StudentsDetailsViewModel()
        {
            this.studentEmails = new List<string>();
        }
    }
}