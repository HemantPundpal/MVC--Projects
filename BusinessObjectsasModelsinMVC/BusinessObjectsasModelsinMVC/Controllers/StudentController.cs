using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;
using BusinessObjectsasModelsinMVC.Models;

namespace BusinessObjectsasModelsinMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student Index
        public ActionResult Index()
        {
            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
            StudentIndexViewModel studentIndexModel = new StudentIndexViewModel();
            List<StudentsDetailsViewModel> studentDetailsViewModelList = new List<StudentsDetailsViewModel>();
            foreach(StudentDetails studentDetails in studentBusinessLayer.studentListWithDetails)
            {
                studentDetailsViewModelList.Add(new StudentsDetailsViewModel());
                studentDetailsViewModelList.Last().Id = studentDetails.Id;
                studentDetailsViewModelList.Last().FirstName = studentDetails.FirstName;
                studentDetailsViewModelList.Last().LastName = studentDetails.LastName;

                foreach (string strStudentEmail in studentDetails.studentEmails)
                {
                    studentDetailsViewModelList.Last().studentEmails.Add(strStudentEmail);
                }
            }
            studentIndexModel.viewStudentListWithDetails = studentDetailsViewModelList;
            return View(studentIndexModel.viewStudentListWithDetails);
        }

        // GET: Student Details
        public ActionResult Details(int studentId)
        {
            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
            StudentsDetailsViewModel studentDetailsModel = new StudentsDetailsViewModel();

            studentDetailsModel.Id = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().Id;
            studentDetailsModel.FirstName = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().FirstName;
            studentDetailsModel.LastName = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().LastName;
            foreach (string strStudentEmail in studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().studentEmails)
            {
                studentDetailsModel.studentEmails.Add(strStudentEmail);
            }

            return View(studentDetailsModel);
        }

        // GET: Student Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Student Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                StudentDetails studentDetails = new StudentDetails();

                studentDetails.FirstName = formCollection["FirstName"];
                studentDetails.LastName = formCollection["LastName"];
                studentDetails.studentEmails.Add(formCollection["Student Email"]);

                StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
                studentBusinessLayer.AddStudent(studentDetails);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Student Edit
        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
            StudentsDetailsViewModel studentDetailsModel = new StudentsDetailsViewModel();

            studentDetailsModel.Id = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().Id;
            studentDetailsModel.FirstName = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().FirstName;
            studentDetailsModel.LastName = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().LastName;
            foreach (string strStudentEmail in studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().studentEmails)
            {
                studentDetailsModel.studentEmails.Add(strStudentEmail);
            }

            return View(studentDetailsModel);
        }

        // POST: Student Edit
        [HttpPost]
        public ActionResult Edit(/*StudentsDetailsViewModel studentDetailsModel*/)
        {
            StudentsDetailsViewModel studentDetailsModel = new StudentsDetailsViewModel();
            UpdateModel<IStudentDetails>(studentDetailsModel);

            if (ModelState.IsValid)
            {
                StudentDetails studentDetails = new StudentDetails();

                studentDetails.Id = studentDetailsModel.Id;
                studentDetails.FirstName = studentDetailsModel.FirstName;
                studentDetails.LastName = studentDetailsModel.LastName;
                foreach (string strStudentEmail in studentDetailsModel.studentEmails)
                {
                    studentDetails.studentEmails.Add(strStudentEmail);
                }

                StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
                studentBusinessLayer.UpdateStudent(studentDetails);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Add Student Email
        [HttpGet]
        public ActionResult AddEmail(int studentId)
        {
            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
            StudentsDetailsViewModel studentDetailsModel = new StudentsDetailsViewModel();

            studentDetailsModel.Id = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().Id;
            studentDetailsModel.FirstName = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().FirstName;
            studentDetailsModel.LastName = studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().LastName;
            foreach (string strStudentEmail in studentBusinessLayer.studentListWithDetails.Where(stuDetails => stuDetails.Id == studentId).Single().studentEmails)
            {
                studentDetailsModel.studentEmails.Add(strStudentEmail);
            }

            return View(studentDetailsModel);
        }

        // POST: Add Student Email
        [HttpPost]
        public ActionResult AddEmail(FormCollection formCollection)
        {

            StudentDetails studentDetails = new StudentDetails();
            StudentsDetailsViewModel studentDetailsModel = new StudentsDetailsViewModel();

            studentDetails.Id = Convert.ToInt32(formCollection["Id"]);
            studentDetails.studentEmails.Add(formCollection["Student Email"]);

            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
            studentBusinessLayer.AddStudentEmail(studentDetails);

            return RedirectToAction("Index");
        }

        // GET: Student Delete
        [HttpPost]
        public ActionResult Delete(int StudentId)
        {
            StudentDetails studentDetails = new StudentDetails();

            studentDetails.Id = StudentId;

            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
            studentBusinessLayer.DeleteStudent(studentDetails);

            return RedirectToAction("Index");
        }
    }
}