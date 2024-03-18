using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtraController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<ExtraController> _logger;

        public ExtraController(CricksDataContext context, ILogger<ExtraController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /extra
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var extras = await _context.Extras.ToListAsync();
                _logger.LogInformation("Fetched all extras");
                return Ok(extras);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching extras");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /extra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var extra = await _context.Extras.FindAsync(id);

                if (extra == null)
                {
                    _logger.LogWarning("Extra with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched extra with id {id}", id);
                return Ok(extra);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching extra with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /extra
        [HttpPost]
        public async Task<IActionResult> Post(Extra extra)
        {
            try
            {
                _context.Extras.Add(extra);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created extra with id {id}", extra.ExtraId);
                return CreatedAtAction(nameof(Get), new { id = extra.ExtraId }, extra);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating extra");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /extra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Extra extra)
        {
            if (id != extra.ExtraId)
            {
                _logger.LogWarning("Mismatch between extra id in URL and body");
                return BadRequest();
            }

            try
            {
                _context.Entry(extra).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated extra with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating extra with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: /extra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var extra = await _context.Extras.FindAsync(id);

                if (extra == null)
                {
                    _logger.LogWarning("Extra with id {id} not found", id);
                    return NotFound();
                }

                _context.Extras.Remove(extra);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted extra with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting extra with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
