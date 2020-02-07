using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;

namespace BusinessObjectsasModelsinMVC.Models
{
    public class StudentIndexViewModel
    {
        public List<StudentsDetailsViewModel> viewStudentListWithDetails { get; set; }
    }
}