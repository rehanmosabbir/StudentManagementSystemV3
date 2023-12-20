using StudentManagementSystemV3.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemV3.Core.Models
{
    public class SemesterModel
    {
        public int Id { get; set; }
        public SemesterCode SemesterCode { get; set; }
        public string? Year { get; set; }
        public IList<StudentModel> Students { get; set; }
    }
}
