using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dto;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Scorer")]
    public class ScoringController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<ScoringController> _logger;

        public ScoringController(CricksDataContext context, ILogger<ScoringController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // POST: /scoring
        [HttpPost]
        public async Task<IActionResult> Post(ScoringDto scoring)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Create a new ball
                var ball = new Ball
                {
                    InningsId = scoring.InningsId,
                    BowlerId = scoring.BowlerId,
                    BatsmanId = scoring.StrikerBatsmanId,
                    Runs = scoring.Runs,
                    IsBye = scoring.IsBye,
                    IsLegBye = scoring.IsLegBye,
                    IsWicket = scoring.IsWicket,
                    IsRetiredHurt = scoring.IsRetiredHurt,
                    IsWide = scoring.IsWide,
                    IsNoBall = scoring.IsNoBall,
                    FielderId = scoring.FielderId,
                    SecondFielderId = scoring.SecondFielderId,
                    CreatedBy = User.Identity.Name,
                    CreatedOn = DateTime.UtcNow
                };
                _context.Balls.Add(ball);

                // Create a new extra run if necessary
                if (scoring.IsBye || scoring.IsLegBye || scoring.IsWide || scoring.IsNoBall)
                {
                    var extra = new Extra
                    {
                        InningsId = scoring.InningsId,
                        ExtraTypeId = (int)scoring.ExtraTypeId,
                        Runs = scoring.Runs,
                        CreatedBy = User.Identity.Name,
                        CreatedDate = DateTime.UtcNow
                    };
                    _context.Extras.Add(extra);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation("Created scoring with ball id {id}", ball.BallId);

                // Calculate the new striker and non-striker batsman IDs
                var newStrikerBatsmanId = scoring.Runs % 2 == 0 ? scoring.StrikerBatsmanId : scoring.NonStrikerBatsmanId;
                var newNonStrikerBatsmanId = scoring.Runs % 2 == 0 ? scoring.NonStrikerBatsmanId : scoring.StrikerBatsmanId;

                // Check if the over is completed
                var overCompleted = await _context.Balls.CountAsync(b => b.InningsId == scoring.InningsId) % 6 == 0;

                return Ok(new { newStrikerBatsmanId, newNonStrikerBatsmanId, overCompleted });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error creating scoring");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
