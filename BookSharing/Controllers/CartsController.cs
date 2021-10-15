using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookSharing.Models;

namespace BookSharing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly BookSharingContext _context;

        public CartsController(BookSharingContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("usercart/{userId}")]
        public async Task<ActionResult<Cart>> GetUserCart(int userId)
        {
            var cart = await _context.Carts.Where(
                                 cart => cart.UserId == userId)
                    .FirstOrDefaultAsync();

            _context.Entry(cart)
                .Collection(ct => ct.CartItems)
                .Query()
                .Include(ct=>ct.Book)
                .Load();

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }


        //get the cart details for specific user
        //[HttpGet("userCart/{userId}")]
        //public async Task<ActionResult<Cart>> GetUserCart(int userId)
        //{
        //    var cart = await _context.Carts.Where(
        //                     cart => cart.UserId == userId)
        //        .FirstOrDefaultAsync();

        //    _context.Entry(cart)
        //        .Collection(ct => ct.CartItems)
        //        .Load();

        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    return cart;
        //}

        // PUT: api/Carts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> DeleteCart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
    }
}
