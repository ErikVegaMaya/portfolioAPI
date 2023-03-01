using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly PortfolioContext _dbContex;
        public EducationController(PortfolioContext dbContex)
        {
            _dbContex= dbContex;
        }

        // GET: api/<EducationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> Get()
        {
            List<Education> educations = await _dbContex.Educations.ToListAsync<Education>();
            return Ok(educations);
        }

        // GET api/<EducationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> Get(int id)
        {
            var education = await _dbContex.Educations.FindAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);
        }

        // POST api/<EducationController>
        [HttpPost]
        public async Task<ActionResult<Education>> Post([FromBody] Education education)
        {
            await _dbContex.Educations.AddAsync(education);
            await _dbContex.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<EducationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Education>> Put(int id, [FromBody] Education education)
        {
            if (id != education.IdEdu)
            {
                return BadRequest();
            }

            _dbContex.Entry(education).State= EntityState.Modified;
            await _dbContex.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<EducationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Education>> Delete(int id)
        {
            var education = await _dbContex.Educations.FindAsync(id);
            if (education == null) { return NotFound(); }
            _dbContex.Educations.Remove(education);
            await _dbContex.SaveChangesAsync();
            return Ok();
        }
    }
}
