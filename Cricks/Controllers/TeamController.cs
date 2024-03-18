using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Manager,Admin,Owner")]
    public class TeamController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<TeamController> _logger;

        public TeamController(CricksDataContext context, ILogger<TeamController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /team
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var teams = await _context.Teams.ToListAsync();
                _logger.LogInformation("Fetched all teams");
                return Ok(teams);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching teams");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /team/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var team = await _context.Teams.FindAsync(id);

                if (team == null)
                {
                    _logger.LogWarning("Team with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched team with id {id}", id);
                return Ok(team);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching team with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /team
        [HttpPost]
        public async Task<IActionResult> Post(Team team)
        {
            try
            {
                team.CreatedBy = User.Identity.Name;
                team.CreatedDate = DateTime.UtcNow;
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created team with id {id}", team.TeamId);
                return CreatedAtAction(nameof(Get), new { id = team.TeamId }, team);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating team");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /team/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Team team)
        {
            if (id != team.TeamId)
            {
                _logger.LogWarning("Mismatch between team id in URL and body");
                return BadRequest();
            }

            try
            {
                team.ModifiedBy = User.Identity.Name;
                team.ModifiedDate = DateTime.UtcNow;
                _context.Entry(team).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated team with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating team with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }


        // DELETE: /team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var team = await _context.Teams.FindAsync(id);

                if (team == null)
                {
                    _logger.LogWarning("Team with id {id} not found", id);
                    return NotFound();
                }

                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted team with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting team with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
