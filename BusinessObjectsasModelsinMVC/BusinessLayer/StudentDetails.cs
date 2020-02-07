using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IStudentDetails
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        List<string> studentEmails { get; set; }
    }
    public class StudentDetails : IStudentDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> studentEmails { get; set; }

        public StudentDetails()
        {
            this.studentEmails = new List<string>();
        }
    }
}
