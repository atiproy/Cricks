using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cricks.Data.DbModels;
using System.Threading.Tasks;
using Cricks.Data;
using Microsoft.Extensions.Logging;
using System;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerTypeController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<PlayerTypeController> _logger;

        public PlayerTypeController(CricksDataContext context, ILogger<PlayerTypeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /playertype
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var playerTypes = await _context.PlayerTypes.ToListAsync();
                _logger.LogInformation("Fetched all player types");
                return Ok(playerTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching player types");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /playertype/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var playerType = await _context.PlayerTypes.FindAsync(id);

                if (playerType == null)
                {
                    _logger.LogWarning("Player type with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched player type with id {id}", id);
                return Ok(playerType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching player type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /playertype
        [HttpPost]
        public async Task<IActionResult> Post(PlayerType playerType)
        {
            try
            {
                _context.PlayerTypes.Add(playerType);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created player type with id {id}", playerType.PlayerTypeId);
                return CreatedAtAction(nameof(Get), new { id = playerType.PlayerTypeId }, playerType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating player type");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /playertype/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PlayerType playerType)
        {
            if (id != playerType.PlayerTypeId)
            {
                _logger.LogWarning("Mismatch between player type id in URL and body");
                return BadRequest();
            }

            try
            {
                _context.Entry(playerType).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated player type with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating player type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: /playertype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var playerType = await _context.PlayerTypes.FindAsync(id);

                if (playerType == null)
                {
                    _logger.LogWarning("Player type with id {id} not found", id);
                    return NotFound();
                }

                _context.PlayerTypes.Remove(playerType);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted player type with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting player type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
