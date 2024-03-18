using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BallController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<BallController> _logger;

        public BallController(CricksDataContext context, ILogger<BallController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /ball
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var balls = await _context.Balls.ToListAsync();
                _logger.LogInformation("Fetched all balls");
                return Ok(balls);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching balls");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /ball/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ball = await _context.Balls.FindAsync(id);

                if (ball == null)
                {
                    _logger.LogWarning("Ball with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched ball with id {id}", id);
                return Ok(ball);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching ball with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /ball
        [HttpPost]
        public async Task<IActionResult> Post(Ball ball)
        {
            try
            {
                _context.Balls.Add(ball);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created ball with id {id}", ball.BallId);
                return CreatedAtAction(nameof(Get), new { id = ball.BallId }, ball);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ball");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /ball/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ball ball)
        {
            if (id != ball.BallId)
            {
                _logger.LogWarning("Mismatch between ball id in URL and body");
                return BadRequest();
            }

            try
            {
                _context.Entry(ball).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated ball with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ball with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: /ball/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ball = await _context.Balls.FindAsync(id);

                if (ball == null)
                {
                    _logger.LogWarning("Ball with id {id} not found", id);
                    return NotFound();
                }

                _context.Balls.Remove(ball);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted ball with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting ball with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
