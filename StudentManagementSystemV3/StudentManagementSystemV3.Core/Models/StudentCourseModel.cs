using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemV3.Core.Models
{
    public class StudentCourseModel
    {
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }

        public int CourseId { get; set; }
        public CourseModel Course { get; set; }
    }
}
