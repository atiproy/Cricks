using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InningsController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<InningsController> _logger;

        public InningsController(CricksDataContext context, ILogger<InningsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /innings
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var innings = await _context.Innings.ToListAsync();
                _logger.LogInformation("Fetched all innings");
                return Ok(innings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching innings");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /innings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var innings = await _context.Innings.FindAsync(id);

                if (innings == null)
                {
                    _logger.LogWarning("Innings with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched innings with id {id}", id);
                return Ok(innings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching innings with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /innings
        [HttpPost]
        public async Task<IActionResult> Post(Innings innings)
        {
            try
            {
                _context.Innings.Add(innings);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created innings with id {id}", innings.InningsId);
                return CreatedAtAction(nameof(Get), new { id = innings.InningsId }, innings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating innings");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /innings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Innings innings)
        {
            if (id != innings.InningsId)
            {
                _logger.LogWarning("Mismatch between innings id in URL and body");
                return BadRequest();
            }

            try
            {
                _context.Entry(innings).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated innings with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating innings with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: /innings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var innings = await _context.Innings.FindAsync(id);

                if (innings == null)
                {
                    _logger.LogWarning("Innings with id {id} not found", id);
                    return NotFound();
                }

                _context.Innings.Remove(innings);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted innings with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting innings with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
