using BookSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookSharingContext _context;

        public  AuthorRepository(BookSharingContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }

        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(author);
            return author;
        }

        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            //throw new NotImplementedException();
            //Explicit loading
            var author = await _context.Authors.SingleAsync(auth => auth.Id == id);

            //related data
            //_context.Entry(author)
            //        .Collection(auth => auth.Books)
            //        .Load();
           

            return author;

        }

        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            //throw new NotImplementedException();
            return await _context.Authors.ToListAsync();
        }

        public Task<IActionResult> PutAuthor(int id, Author author)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
