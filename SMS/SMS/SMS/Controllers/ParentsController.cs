using Microsoft.AspNetCore.Mvc;
using SMS.Shared.Models;
using SMS.Shared.ParentRepository;

namespace SMS.Controllers
{
    [Route("api/parents")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentRepository _parentRepository;

        public ParentsController(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

        // GET: api/Parents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parent>>> GetParents()
        {
            return await _parentRepository.GetAllParentsAsync();
        }

        // GET: api/Parents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> GetParent(int id)
        {
            var parent = await _parentRepository.GetParentByIdAsync(id);
            
            return parent;
        }

        // PUT: api/Parents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParent(int id, Parent parent)
        {
            var candidate = await _parentRepository.UpdateParentAsync(id, parent);

            return Ok(candidate);
        }

        // POST: api/Parents
        [HttpPost]
        public async Task<ActionResult<Parent>> PostParent(Parent parent)
        {
            var candidate = await _parentRepository.AddParentAsync(parent);
            return Ok(candidate);
        }

        // DELETE: api/Parents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parent = await _parentRepository.DeleteParentAsync(id);
            return Ok(parent);
        }
        
    }
}
