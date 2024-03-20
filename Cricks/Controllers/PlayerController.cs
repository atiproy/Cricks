using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dto;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(CricksDataContext context, ILogger<PlayerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /player
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var players = await _context.Players.ToListAsync();
                _logger.LogInformation("Fetched all players");
                return Ok(players);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching players");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /player/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var player = await _context.Players.FindAsync(id);

                if (player == null)
                {
                    _logger.LogWarning("Player with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched player with id {id}", id);
                return Ok(player);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching player with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /player
        [HttpPost]
        public async Task<IActionResult> Post(PlayerDTO playerDto)
        {
            try
            {
                var player = new Player
                {
                    // Map properties from DTO to Player
                    Name = playerDto.Name,
                    TeamId = playerDto.TeamId,
                    PlayerTypeId = playerDto.PlayerTypeId,
                    Rating = playerDto.Rating,
                    Comments = playerDto.Comments,
                    CreatedBy = playerDto.CreatedBy,
                    ModifiedBy = playerDto.ModifiedBy,
                    CreatedDate = playerDto.CreatedDate,
                    ModifiedDate = playerDto.ModifiedDate,
                    IsCaptain = playerDto.IsCaptain
                };

                _context.Players.Add(player);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created player with id {id}", player.PlayerId);
                return CreatedAtAction(nameof(Get), new { id = player.PlayerId }, player);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating player");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /player/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PlayerDTO playerDto)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                _logger.LogWarning("Player with id {id} not found", id);
                return NotFound();
            }

            // Map properties from DTO to Player
            player.Name = playerDto.Name ?? "";
            player.TeamId = playerDto.TeamId ?? default(int);
            player.PlayerTypeId = playerDto.PlayerTypeId ?? default(int);
            player.Rating = playerDto.Rating ?? default(int);
            player.Comments = playerDto.Comments ?? "";
            player.CreatedBy = playerDto.CreatedBy ?? "";
            player.ModifiedBy = playerDto.ModifiedBy ?? "";
            player.CreatedDate = playerDto.CreatedDate ?? default(DateTime);
            player.ModifiedDate = playerDto.ModifiedDate ?? default(DateTime);
            player.IsCaptain = playerDto.IsCaptain;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Updated player with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating player with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }


        // DELETE: /player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var player = await _context.Players.FindAsync(id);

                if (player == null)
                {
                    _logger.LogWarning("Player with id {id} not found", id);
                    return NotFound();
                }

                _context.Players.Remove(player);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted player with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting player with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
