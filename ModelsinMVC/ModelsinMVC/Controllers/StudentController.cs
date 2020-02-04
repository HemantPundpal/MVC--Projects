using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsinMVC.Models;


namespace ModelsinMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentContext studentContext1 = new StudentContext();
            StudentView studentView = new StudentView();
            studentView.studentList = studentContext1.Students.ToList();
            studentView.studentEmailList = studentContext1.Emails.ToList();


            return View(studentView);
        }

        // GET: Student
        public ActionResult Details(int studentId)
        {
            StudentContext studentContext1 = new StudentContext();
            StudentDetails studentDetails = new StudentDetails();
            Student student = studentContext1.Students.Single(stu => stu.Id == studentId);
            List<StudentEmail> studentEmailList = studentContext1.Emails.Where(stuEmailList => stuEmailList.StudentId == studentId).ToList();

            studentDetails.Id = student.Id;
            studentDetails.FirstName = student.FirstName;
            studentDetails.LastName = student.LastName;

            foreach (var studentEmail in studentEmailList)
            {
                if (studentEmail.StudentId == studentId)
                {
                    studentDetails.StudentEmailList.Add(studentEmail.Email);
                }
            }

            return View(studentDetails);
        }
    }
}