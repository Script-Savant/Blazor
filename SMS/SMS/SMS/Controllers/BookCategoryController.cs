using Microsoft.AspNetCore.Mvc;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Controllers
{
    [Route("api/book-category")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryRepository _repo;

        public BookCategoryController(IBookCategoryRepository repo)
        {
            _repo = repo;
        }

        // GET: api/BookCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategory>>> GetBookCategories()
        {
            return await _repo.GetAll();
        }

        // GET: api/BookCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookCategory>> GetBookCategory(int id)
        {
            var bookCategory = await _repo.GetById(id);

            return bookCategory;
        }

        // PUT: api/BookCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookCategory(int id, BookCategory bookCategory)
        {
            if (id != bookCategory.Id)
            {
                return BadRequest();
            }
            await _repo.Update(id, bookCategory);

            return Ok(bookCategory);
        }

        // POST: api/BookCategory
        [HttpPost]
        public async Task<ActionResult<BookCategory>> PostBookCategory(BookCategory bookCategory)
        {
            await _repo.Create(bookCategory);

            return Ok(bookCategory);
        }

        // DELETE: api/BookCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCategory(int id)
        {
            var bookCategory = await _repo.Delete(id);
            
            return Ok(bookCategory);
        }
    }
}
