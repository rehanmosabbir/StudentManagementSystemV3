using StudentManagementSystemV3.Core.Interfaces;
using StudentManagementSystemV3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemV3.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<StudentModel>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
