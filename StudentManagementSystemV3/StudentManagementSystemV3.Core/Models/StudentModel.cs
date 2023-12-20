using StudentManagementSystemV3.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemV3.Core.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string StudentID { get; set; }
        public int JoiningBatch { get; set; } // Reference to Semester
        public Department Department { get; set; }
        public Degree Degree { get; set; }
        public IList<CourseModel> CoursesAttended { get; set; }
        public ICollection<SemesterModel> SemestersAttended { get; set; }
    }
}
