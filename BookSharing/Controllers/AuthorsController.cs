using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookSharing.Models;
using BookSharing.Repository;

namespace BookSharing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookSharingContext _context;
        //private readonly IAuthorRepository _authorRepository;

        public AuthorsController(BookSharingContext context)
        {
            _context = context;
            //_authorRepository = authorRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
            //return Ok(await _authorRepository.GetAuthors());

        }

        // GET: api/Authors/5
        [HttpGet("GetAuthor/{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            //earger loading
            //var author = await _context.Authors
            //                    .Include(author => author.Books)  // for loading related data
            //                    .Where(author => author.Id == id)
            //                    .FirstOrDefaultAsync();

            //Explicit loading
            var author = await _context.Authors.SingleAsync(auth => auth.Id == id);

            //related data
            //_context.Entry(author)
            //        .Collection(auth => auth.Books)
            //        .Load();

            //loading data with specific condition
            _context.Entry(author)
                    .Collection(auth => auth.Books)
                    .Query()
                    .Where(book => book.BookPrice <= 300) //load book less= 300
                    .Load();

            //var author = await _authorRepository.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
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
                if (!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            //_authorRepository.AddAuthor(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            //var author = await _authorRepository.DeleteAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

           _context.Authors.Remove(author);
            //await _authorRepository.SaveAsync();

            return author;
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
