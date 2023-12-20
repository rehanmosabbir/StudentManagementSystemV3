using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemV3.Core.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public int NumberOfCredits { get; set; }
        public IList<StudentModel> Students { get; set; }
    }
}
