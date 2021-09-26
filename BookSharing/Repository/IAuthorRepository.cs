using BookSharing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Repository
{
    public interface IAuthorRepository
    {
        Task<ActionResult<IEnumerable<Author>>> GetAuthors();

        Task<ActionResult<Author>> GetAuthor(int id);

        Task<IActionResult> PutAuthor(int id, Author author);

        void AddAuthor(Author author);

        Task<ActionResult<Author>> DeleteAuthor(int id);

        bool AuthorExists(int id);

        Task<bool> SaveAsync();
    }
}
