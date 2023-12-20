using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemV3.Core.Models;
using StudentManagementSystemV3.Services.Interfaces;

namespace StudentManagementSystemV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentManagementSystemController : ControllerBase
    {
        private readonly ILogger<StudentManagementSystemController> _logger;

        private readonly IStudentService _studentService;



        public StudentManagementSystemController(ILogger<StudentManagementSystemController> logger,
         IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _studentService.GetAllStudents();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _studentService.GetStudentById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentModel sModel)
        {
            var isProductCreated = await _studentService.CreateStudent(sModel);

            if (isProductCreated)
            {
                return Ok(isProductCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentModel sModel)
        {
            if (sModel != null)
            {
                var isStudentCreated = await _studentService.UpdateStudent(sModel);
                if (isStudentCreated)
                {
                    return Ok(isStudentCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int sId)
        {
            var isStudentCreated = await _studentService.DeleteStudent(sId);

            if (isStudentCreated)
            {
                return Ok(isStudentCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
