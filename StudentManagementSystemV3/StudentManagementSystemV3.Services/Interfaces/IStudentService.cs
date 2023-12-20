using StudentManagementSystemV3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemV3.Services.Interfaces
{
    public interface IStudentService
    {
        Task<bool> CreateStudent(StudentModel sModel);
        Task<bool> DeleteStudent(int studentId);
        Task<IEnumerable<StudentModel>> GetAllStudents();
        Task<StudentModel> GetStudentById(int studentId);
        Task<bool> UpdateStudent(StudentModel studentModel);
    }
}
