using Microsoft.AspNetCore.Mvc;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _repo;

        public SubjectsController(ISubjectRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return await _repo.GetAllSubjects();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _repo.GetSubjectById(id);
            
            return subject;
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            var candidate = await _repo.UpdateSubject(id, subject);

            return Ok(candidate);
        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            var candidate = await _repo.AddSubject(subject);
            return Ok(candidate);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _repo.DeleteSubject(id);
            return Ok(subject);
        }
        
    }
}
