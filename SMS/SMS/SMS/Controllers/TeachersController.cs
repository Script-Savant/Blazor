using Microsoft.AspNetCore.Mvc;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repo;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _repo = teacherRepository;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _repo.GetAllTeachers();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _repo.GetTeacherById(id);
            
            return teacher;
        }

        // PUT: api/Teachers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            var candidate = await _repo.UpdateTeacher(id, teacher);
            return Ok(candidate);
        }

        // POST: api/Teachers
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            var candidate = await _repo.AddTeacher(teacher);
            
            return Ok(candidate);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _repo.DeleteTeacher(id);
            return Ok(teacher);
        }
    }
}
