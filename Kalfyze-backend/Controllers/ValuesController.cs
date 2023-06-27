using System.Net;
using System.Security.Principal;
using System.Xml.Linq;
using Kalfyze_backend.Data;
using Kalfyze_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kalfyze_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private KalfyzeDbContext _context;

        public ValuesController(KalfyzeDbContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet, Route("getcontenttypes")]
        public async Task<IEnumerable<Content_Type>> Get()
        {
            
            return await _context.ContentTypes.ToListAsync();
        }

        [HttpGet, Route("getcontenttypes/{id:int}")]
        public ActionResult<Content_Type> Get(int id)
        {
            var contenttype = _context.ContentTypes.Find(id);
            if (contenttype != null)
            {
                return contenttype;
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/<ValuesController>
        [HttpGet, Route("getcontent")]
        public async Task<ActionResult<IEnumerable<Content>>> GetContent()
        {
            return Ok(await _context.Contents.Include(x => x.Type).Include(x => x.Franchise).ToListAsync());
        }
        

        // POST api/<ValuesController>
        [HttpPost, Route("postcontenttype")]
        public void Post(string value)
        {
            var contentType = new Content_Type();
            contentType.Name = value;
            _context.ContentTypes.Add(contentType);
            _context.SaveChanges();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete, Route("deletecontenttype/{id:int}")]
        public IActionResult Delete(int id)
        {
            var contenttype = _context.ContentTypes.Find(id);
            if (contenttype != null)
            {
                _context.ContentTypes.Remove(contenttype);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
