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

        [HttpPost]
        public async Task<IActionResult> Post(ScoringDto scoring)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Calculate total runs
                var totalRuns = scoring.BatsmanRun + scoring.LegBye + scoring.Bye + scoring.PenaltyRun;
                if (scoring.IsWide || scoring.IsNoBall)
                {
                    totalRuns += 1;
                }

                // Calculate over number and ball number
                var totalBalls = await _context.Balls.CountAsync(b => b.InningsId == scoring.InningsId && !b.IsWide && !b.IsNoBall);
                var overNumber = totalBalls / 6 + 1;
                var ballNumber = totalBalls % 6 + 1;


                // Create a new ball
                var ball = new Ball
                {
                    InningsId = scoring.InningsId,
                    OverNumber = overNumber,
                    BallNumber = ballNumber,
                    BowlerId = scoring.BowlerId,
                    BatsmanId = scoring.StrikerBatsmanId,
                    Runs = totalRuns,
                    BatsmanRun = scoring.BatsmanRun,
                    Bye = scoring.Bye,
                    LegBye = scoring.LegBye,
                    PenaltyRun = scoring.PenaltyRun,
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

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation("Created scoring with ball id {id}", ball.BallId);

                // Calculate the new striker and non-striker batsman IDs
                var newStrikerBatsmanId = totalRuns % 2 == 0 ? scoring.StrikerBatsmanId : scoring.NonStrikerBatsmanId;
                var newNonStrikerBatsmanId = totalRuns % 2 == 0 ? scoring.NonStrikerBatsmanId : scoring.StrikerBatsmanId;

                // Check if the over is completed
                var overCompleted = ballNumber == 6;

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
