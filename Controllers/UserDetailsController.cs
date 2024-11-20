using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private readonly UserContext _context;

        public UserDetailsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserItem>>> GetUserItems()
        {
            var userItems = await _context.UserItems.ToListAsync();
            return Ok(userItems);
        }

        // GET: api/UserDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserItem>> GetUserItem(long id)
        {
            var userItem = await _context.UserItems.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }

            return Ok(userItem);
        }

        // POST: api/UserDetails
        [HttpPost]
        public async Task<ActionResult<UserItem>> PostUserItem(UserItem userItem)
        {
            if (userItem == null)
            {
                return BadRequest("UserItem cannot be null.");
            }

            await _context.UserItems.AddAsync(userItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserItem), new { id = userItem.Id }, userItem);
        }

        // PUT: api/UserDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserItem(long id, UserItem userItem)
        {
            if (id != userItem.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            _context.Entry(userItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserItemExistsAsync(id))
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

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserItem(long id)
        {
            var userItem = await _context.UserItems.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }

            _context.UserItems.Remove(userItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> UserItemExistsAsync(long id)
        {
            return await _context.UserItems.AnyAsync(e => e.Id == id);
        }
    }
}
