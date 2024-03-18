using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CricketMatchController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<CricketMatchController> _logger;

        public CricketMatchController(CricksDataContext context, ILogger<CricketMatchController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /cricketmatch
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cricketMatches = await _context.CricketMatches.ToListAsync();
                _logger.LogInformation("Fetched all cricket matches");
                return Ok(cricketMatches);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cricket matches");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /cricketmatch/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cricketMatch = await _context.CricketMatches.FindAsync(id);

                if (cricketMatch == null)
                {
                    _logger.LogWarning("Cricket match with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched cricket match with id {id}", id);
                return Ok(cricketMatch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cricket match with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /cricketmatch
        [HttpPost]
        public async Task<IActionResult> Post(CricketMatch cricketMatch)
        {
            try
            {
                _context.CricketMatches.Add(cricketMatch);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created cricket match with id {id}", cricketMatch.MatchId);
                return CreatedAtAction(nameof(Get), new { id = cricketMatch.MatchId }, cricketMatch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cricket match");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /cricketmatch/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CricketMatch cricketMatch)
        {
            if (id != cricketMatch.MatchId)
            {
                _logger.LogWarning("Mismatch between cricket match id in URL and body");
                return BadRequest();
            }

            try
            {
                _context.Entry(cricketMatch).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated cricket match with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cricket match with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: /cricketmatch/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cricketMatch = await _context.CricketMatches.FindAsync(id);

                if (cricketMatch == null)
                {
                    _logger.LogWarning("Cricket match with id {id} not found", id);
                    return NotFound();
                }

                _context.CricketMatches.Remove(cricketMatch);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted cricket match with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting cricket match with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
