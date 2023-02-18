using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly PortfolioContext _dbContext;
        public ExperienceController(PortfolioContext dbContext)
        {
            _dbContext= dbContext;
        }

        // GET: api/<ExperienceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>>  GetExperiences()
        {
            List<Experience> experiences = await _dbContext.Experiences.ToListAsync<Experience>();
            return Ok(experiences);
        }

        // GET api/<ExperienceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(int id)
        {
            var experience  = await _dbContext.Experiences.FindAsync(id);

            if (experience == null)
            {
                return NotFound(); 
            }

            return Ok(experience);
        }

        // POST api/<ExperienceController>
        [HttpPost]
        public async Task<ActionResult<Experience>> Post([FromBody] Experience experience)
        {
            await _dbContext.Experiences.AddAsync(experience);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<ExperienceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Experience>> Put(int id, [FromBody] Experience experience)
        {
            if (id != experience.IdExp)
            {
                return BadRequest();
            }

            _dbContext.Entry(experience).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ExperienceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Experience>> Delete(int id)
        {
            var experience = await _dbContext.Experiences.FindAsync(id);
            if(experience == null) { return NotFound(); }
            _dbContext.Experiences.Remove(experience);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
