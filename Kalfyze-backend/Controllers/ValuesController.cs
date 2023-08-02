using Kalfyze_backend.Models.DTO;
using Kalfyze_backend.Models.Entities;
using Kalfyze_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kalfyze_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IService _valuesService;

        public ValuesController(IService valuesService)
        { 
            _valuesService = valuesService;
        }

        // GET: api/<ValuesController>
        [HttpGet, Route("getcontenttypes")]
        public async Task<IEnumerable<ContentTypeDTO>> GetAllContentTypes()
        {
            
            return await _valuesService.GetAllContentTypes();
        }

        [HttpGet, Route("getcontenttypes/{id:int}")]
        public async Task<ActionResult<ContentTypeDTO>> GetContentTypeById(int id)
        {
            var contenttype = await _valuesService.GetContentTypeById(id);
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
        public async Task<ActionResult<IEnumerable<Content>>> GetAllContent()
        {
            return Ok(await _valuesService.GetAllContent());
        }
        

        // POST api/<ValuesController>
        [HttpPost, Route("postcontenttype")]
        public void PostContentType(string value)
        {
            _valuesService.AddContentType(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete, Route("deletecontenttype/{id:int}")]
        public async Task<IActionResult> DeleteContentType(int id)
        {
            if (await _valuesService.DeleteContentType(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
