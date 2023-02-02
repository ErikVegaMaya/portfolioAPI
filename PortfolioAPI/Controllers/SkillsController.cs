using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly PortfolioContext _dbContext;

        public SkillsController(PortfolioContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/<SkillsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
           List<Skill> skills = await  _dbContext.Skills.ToListAsync<Skill>();
           return Ok(skills);

        }

        //GET api/<SkillsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var skill = await _dbContext.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        //POST api/<SkillsController>
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill([FromBody] Skill skill)
        {
            await _dbContext.Skills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<SkillsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Skill>> Put(int id, [FromBody] Skill skill)
        {
            if (id != skill.IdSkill)
            {
                return BadRequest();
            }

            _dbContext.Entry(skill).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<SkillsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Skill>> Delete(int id)
        {
            var skill = await _dbContext.Skills.FindAsync(id);
            if (skill == null) { return NotFound(); }
            _dbContext.Skills.Remove(skill);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        //public bool skillExist(int id)
        //{
        //    return _dbContext.Skills.Any(e => e.IdSkill == id);
        //}
    }
}
