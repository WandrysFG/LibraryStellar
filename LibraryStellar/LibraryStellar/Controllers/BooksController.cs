using LibraryStellar.Entities;
using LibraryStellar.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryStellar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _repository;

        public BooksController(BookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _repository.AddAsync(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Year = book.Year;

            await _repository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return NotFound();

            await _repository.DeleteAsync(book);
            return NoContent();
        }
    }
}
