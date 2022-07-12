using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookBuffetWeb2.DomainClasses;
using BookBuffetWeb2.Data;

namespace BookBuffetWeb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BackendDBContext _context;

        public BooksController(BackendDBContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
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
                if (!BookExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
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

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        [HttpGet("{category}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksbyCategory(string category)
        {
            switch (category.ToLower())
            {
                case "all":
                    return await _context.Books.ToListAsync();
                case "mystery":
                    return await _context.Books.Where(e => e.Category == "mystery").ToListAsync();
                case "thriller":
                    return await _context.Books.Where(e => e.Category == "thriller").ToListAsync();
                case "horror":
                    return await _context.Books.Where(e => e.Category == "horror").ToListAsync();
                case "romance":
                    return await _context.Books.Where(e => e.Category == "romance").ToListAsync();
                case "western":
                    return await _context.Books.Where(e => e.Category == "western").ToListAsync();
                case "sci-fi":
                    return await _context.Books.Where(e => e.Category == "sci-fi").ToListAsync();
                default:
                    return await _context.Books.ToListAsync();
            }
        }

        [HttpGet("User")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksbyUserId([FromQuery] string userid)
        {
            var book = await _context.Books.Where(e => e.UserId == userid).ToListAsync();
            
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksbySearch([FromQuery] string title)
        {
            var book = await _context.Books.Where(e => e.Title.ToLower().Contains(title.Trim().ToLower())).ToListAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }



    }
}
