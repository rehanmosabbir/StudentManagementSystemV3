using Microsoft.Extensions.Logging;
using StudentManagementSystemV3.Core.Interfaces;
using StudentManagementSystemV3.Core.Models;
using StudentManagementSystemV3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemV3.Services
{
    public class StudentService : IStudentService
    {
        public IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {
            var studentList = await _unitOfWork.Students.GetAll();
            return studentList;
        }

        public async Task<StudentModel> GetStudentById(int studentId)
        {
            if (studentId > 0)
            {
                var studentDetails = await _unitOfWork.Students.GetById(studentId);
                if (studentDetails != null)
                {
                    return studentDetails;
                }
            }
            return null;
        }

        public async Task<bool> CreateStudent(StudentModel sModel)
        {
            if (sModel != null)
            {
                await _unitOfWork.Students.Add(sModel);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> UpdateStudent(StudentModel studentModel)
        {
            if (studentModel != null)
            {
                var student = await _unitOfWork.Students.GetById(studentModel.Id);
                if (student != null)
                {
                    student.FirstName = studentModel.FirstName;
                    student.MiddleName = studentModel.MiddleName;
                    student.LastName = studentModel.LastName;
                    student.StudentID = studentModel.StudentID;
                    student.JoiningBatch = studentModel.JoiningBatch;
                    student.Department = studentModel.Department;
                    student.Degree = studentModel.Degree;

                    _unitOfWork.Students.Update(student);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteStudent(int sId)
        {
            if (sId > 0)
            {
                var studentDetails = await _unitOfWork.Students.GetById(sId);
                if (studentDetails != null)
                {
                    _unitOfWork.Students.Delete(studentDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        
    }
}
