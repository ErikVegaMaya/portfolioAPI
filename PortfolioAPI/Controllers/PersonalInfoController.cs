using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly PortfolioContext _dbContext;
        public PersonalInfoController(PortfolioContext dbContext)
        {
            _dbContext= dbContext;
        }

        [HttpGet]
        [Route("getPersonalInfo")]
        public async Task<IActionResult> getPersonalInfo()
        {
            List<PersonalInfo> data = await _dbContext.PersonalInfos.ToListAsync<PersonalInfo>(); 
            return StatusCode(StatusCodes.Status200OK, data);
        }
    }
}
