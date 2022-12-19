using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QwanserApi.Data;
using QwanserApi.Entity;
using System.Text;

namespace QwanserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TagsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags([FromQuery] int id)
        {
            Console.WriteLine("Tag - " + id);

            var tags = await _context.Tags.Where(tag => tag.Id > id).Take(16).OrderBy(item => item.Id).ToListAsync();

            if(tags.Any())
            {
                return tags;
            }

            return NotFound("Tag not founded.");
        }

        [HttpGet("most-popular")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetMostPopularTags([FromQuery] int count)
        {

            var tags = await _context.Tags.Take(count).OrderByDescending(tag => tag.TotalMentions).ToListAsync();

            if (tags.Any())
            {
                return tags;
            }

            return NotFound("Tags not founded.");
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Tag>>> FindTag(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);

            var decodedValue = Encoding.UTF8.GetString(bytes);

            var tags = await _context.Tags.Where(tag => tag.Name.Contains(decodedValue)).ToListAsync();

            if (tags.Any())
            {
                return tags;
            }

            return NotFound("No tags founded.");
        }

    }
}
