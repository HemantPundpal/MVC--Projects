using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentBusinessLayer
    {
        private StudentContext studentContext { get; set; }
        private List<Student> studentList
        {
            get
            {
                return this.studentContext.Students.ToList();
            }
        }
        private List<StudentEmail> studentEmailList
        {
            get
            {
                return this.studentContext.StudentEmails.ToList();
            }
        }
        public List<StudentDetails> studentListWithDetails
        {
            get
            {
                List<StudentDetails> stuListWithDetails = new List<StudentDetails>();
                foreach (Student student in this.studentList)
                {
                    stuListWithDetails.Add(new StudentDetails());
                    stuListWithDetails.Last().Id = student.Id;
                    stuListWithDetails.Last().FirstName = student.FirstName;
                    stuListWithDetails.Last().LastName = student.LastName;

                    foreach (StudentEmail studentEmail in studentEmailList.Where(stuEmails => stuEmails.StudentId == student.Id).ToList())
                    {
                        stuListWithDetails.Last().studentEmails.Add(studentEmail.Email);
                    }
                }
                return stuListWithDetails;
            }
        }

        public StudentBusinessLayer()
        {
            this.studentContext = new StudentContext();
        }

        public void AddStudent(StudentDetails studentDetails)
        {
            StudentContext studentContext = this.studentContext;

            Student student = studentContext.Students.Create();
            student.FirstName = studentDetails.FirstName;
            student.LastName = studentDetails.LastName;
            studentContext.Students.Add(student);
            studentContext.SaveChanges();
        }

        public void UpdateStudent(StudentDetails studentDetails)
        {
            StudentContext studentContext = this.studentContext;

            Student student = studentContext.Students.Where(stu => stu.Id == studentDetails.Id).Single();
            student.FirstName = studentDetails.FirstName;
            student.LastName = studentDetails.LastName;

            studentContext.SaveChanges();

            List<StudentEmail> studentEmailList = studentContext.StudentEmails.Where(stuEmail => stuEmail.StudentId == studentDetails.Id).ToList();
            foreach (string strStudentEmail in studentDetails.studentEmails)
            {
                if (!(string.IsNullOrEmpty(strStudentEmail)))
                {
                    int stuEmailId = studentEmailList.First().Id;
                    StudentEmail studentEmail = studentContext.StudentEmails.Where(stuEmail => stuEmail.Id == stuEmailId).Single();
                    studentEmail.Email = strStudentEmail;

                    studentEmailList.Remove(studentEmailList.First());
                }
            }

            if(studentEmailList.Count != 0)
            {
                foreach (StudentEmail studentEmail in studentEmailList)
                {
                    studentContext.StudentEmails.Remove(studentEmail);
                }
            }

            studentContext.SaveChanges();
        }

        public void AddStudentEmail(StudentDetails studentDetails)
        {
            StudentContext studentContext = this.studentContext;

            StudentEmail studentEmail = studentContext.StudentEmails.Create();
            studentEmail.StudentId = studentDetails.Id;
            studentEmail.Email = studentDetails.studentEmails.Last();
            studentContext.StudentEmails.Add(studentEmail);
            studentContext.SaveChanges();
        }

        public void DeleteStudent(StudentDetails studentDetails)
        {
            StudentContext studentContext = this.studentContext;

            List<StudentEmail> studentEmailList = studentContext.StudentEmails.Where(stuEmail => stuEmail.StudentId == studentDetails.Id).ToList();
            if (studentEmailList.Count != 0)
            {
                foreach (StudentEmail studentEmail in studentEmailList)
                {
                    studentContext.StudentEmails.Remove(studentEmail);
                }
            }
            studentContext.SaveChanges();

            Student student = studentContext.Students.Where(stu => stu.Id == studentDetails.Id).Single();
            studentContext.Students.Remove(student);
            studentContext.SaveChanges();
        }
    }
}
