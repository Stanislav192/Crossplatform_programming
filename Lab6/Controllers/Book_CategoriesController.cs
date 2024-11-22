using Lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class Book_CategoriesController : Controller
    {
        [ApiController]
        [Route("api/[controller]")]
        public class BooksController : ControllerBase
        {
            private readonly BookShopDbContext _context;

            public BooksController(BookShopDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
            {
                return await _context.Books.Include(b => b.Author)
                                           .Include(b => b.BookCategory)
                                           .ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Book>> GetBook(int id)
            {
                var book = await _context.Books.Include(b => b.Author)
                                               .Include(b => b.BookCategory)
                                               .FirstOrDefaultAsync(b => b.BookId == id);

                if (book == null)
                {
                    return NotFound();
                }

                return book;
            }

            [HttpPost]
            public async Task<ActionResult<Book>> CreateBook(Book book)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateBook(int id, Book book)
            {
                if (id != book.BookId)
                {
                    return BadRequest();
                }

                _context.Entry(book).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Books.Any(e => e.BookId == id))
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

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteBook(int id)
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
