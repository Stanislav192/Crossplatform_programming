using Lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class AuthorsController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AuthorsController : ControllerBase
        {
            private readonly BookstoreContext _context;

            public AuthorsController(BookstoreContext context)
            {
                _context = context;
            }

            // GET: api/Authors
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
            {
                return await _context.Authors.ToListAsync();
            }

            // GET: api/Authors/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Author>> GetAuthor(int id)
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                return author;
            }

            // POST: api/Authors
            [HttpPost]
            public async Task<ActionResult<Author>> CreateAuthor(Author author)
            {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
            }

            // PUT: api/Authors/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateAuthor(int id, Author author)
            {
                if (id != author.AuthorId)
                {
                    return BadRequest();
                }

                _context.Entry(author).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Authors.Any(e => e.AuthorId == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // DELETE: api/Authors/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAuthor(int id)
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }

    }
}
