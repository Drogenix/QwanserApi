using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QwanserApi.Data;
using QwanserApi.Entity;

namespace QwanserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] int lastUserId)
        {
            Console.WriteLine("Id - " + lastUserId);

            var users = await _context.Users.Where(user => user.Id > lastUserId).Take(16).OrderBy(user => user.Id).ToListAsync();

            if (users.Any())
            {
                return users;
            }

            return NotFound("Users not found!");
        }

        [HttpGet("find")]
        public async Task<ActionResult<IEnumerable<User>>> FindUsers([FromQuery] string value)
        {
            var users = await _context.Users.Where(user => user.Username.Contains(value)).ToListAsync();

            if (users.Any())
            {
                return users;
            }

            return NotFound("Users not found!");
        }

        [HttpGet("most-active")]
        public async Task<ActionResult<IEnumerable<User>>> GetMostActiveUsers()
        {
            var users = await _context.Users.Take(5).OrderByDescending(user => user.AnswersCount + user.QuestionsCount).ToListAsync();

            if (users.Any())
            {
                return users;
            }

            return NotFound("Users not found!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
