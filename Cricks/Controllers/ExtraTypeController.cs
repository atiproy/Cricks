using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cricks.Data.DbModels;
using System.Threading.Tasks;
using Cricks.Data;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Owner")]
    public class ExtraTypeController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<ExtraTypeController> _logger;

        public ExtraTypeController(CricksDataContext context, ILogger<ExtraTypeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /extratype
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var extraTypes = await _context.ExtraTypes.ToListAsync();
                _logger.LogInformation("Fetched all extra types");
                return Ok(extraTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching extra types");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /extratype/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var extraType = await _context.ExtraTypes.FindAsync(id);

                if (extraType == null)
                {
                    _logger.LogWarning("Extra type with id {id} not found", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched extra type with id {id}", id);
                return Ok(extraType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching extra type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: /extratype
        [HttpPost]
        public async Task<IActionResult> Post(ExtraType extraType)
        {
            try
            {
                _context.ExtraTypes.Add(extraType);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created extra type with id {id}", extraType.ExtraTypeId);
                return CreatedAtAction(nameof(Get), new { id = extraType.ExtraTypeId }, extraType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating extra type");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /extratype/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ExtraType extraType)
        {
            if (id != extraType.ExtraTypeId)
            {
                _logger.LogWarning("Mismatch between extra type id in URL and body");
                return BadRequest();
            }

            try
            {
                _context.Entry(extraType).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated extra type with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating extra type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: /extratype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var extraType = await _context.ExtraTypes.FindAsync(id);

                if (extraType == null)
                {
                    _logger.LogWarning("Extra type with id {id} not found", id);
                    return NotFound();
                }

                _context.ExtraTypes.Remove(extraType);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted extra type with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting extra type with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
