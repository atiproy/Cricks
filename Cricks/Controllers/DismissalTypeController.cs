using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DismissalTypeController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<DismissalTypeController> _logger;

        public DismissalTypeController(CricksDataContext context, ILogger<DismissalTypeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /dismissaltype
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dismissalTypes = await _context.DismissalTypes.ToListAsync();
                _logger.LogInformation("Fetched all dismissal types");
                return Ok(dismissalTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching dismissal types");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /dismissaltype/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var dismissalType = await _context.DismissalTypes.FindAsync(id);

                if (dismissalType == null)
                {
                    _logger.LogWarning("Dismissal type with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched dismissal type with id {id}", id);
                return Ok(dismissalType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching dismissal type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /dismissaltype
        [HttpPost]
        public async Task<IActionResult> Post(DismissalType dismissalType)
        {
            try
            {
                _context.DismissalTypes.Add(dismissalType);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created dismissal type with id {id}", dismissalType.DismissalTypeId);
                return CreatedAtAction(nameof(Get), new { id = dismissalType.DismissalTypeId }, dismissalType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating dismissal type");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /dismissaltype/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DismissalType dismissalType)
        {
            if (id != dismissalType.DismissalTypeId)
            {
                _logger.LogWarning("Mismatch between dismissal type id in URL and body");
                return BadRequest();
            }

            try
            {
                _context.Entry(dismissalType).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated dismissal type with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating dismissal type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: /dismissaltype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dismissalType = await _context.DismissalTypes.FindAsync(id);

                if (dismissalType == null)
                {
                    _logger.LogWarning("Dismissal type with id {id} not found", id);
                    return NotFound();
                }

                _context.DismissalTypes.Remove(dismissalType);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted dismissal type with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting dismissal type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
