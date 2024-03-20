using Cricks.Data;
using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dto;

namespace Cricks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicDataController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<PublicDataController> _logger;

        public PublicDataController(CricksDataContext context, ILogger<PublicDataController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /publicdata/GetTournament/5
        [HttpGet("GetTournament/{id}")]
        public async Task<IActionResult> GetTournament(int id)
        {
            try
            {
                var tournament = await _context.Tournaments
                    .Include(t => t.Groups)
                    .ThenInclude(g => g.TeamStats)
                    .ThenInclude(ts => ts.Team)
                    .FirstOrDefaultAsync(t => t.TournamentId == id);

                if (tournament == null)
                {
                    _logger.LogWarning("Tournament with id {id} not found", id);
                    return NotFound();
                }

                var tourneyDto = new TourneyDto
                {
                    Id = tournament.TournamentId,
                    TournamentName = tournament.Name,
                    TournamentDescription = tournament.Description,
                    Groups = tournament.Groups.Select(g => new TournamentGroupDTO
                    {
                        GroupID = g.GroupId,
                        Name = g.Name,
                        TeamStats = g.TeamStats.Select(ts => new TeamStats
                        {
                            TeamId = ts.TeamId,
                            MatchesPlayed = ts.MatchesPlayed,
                            MatchesWon = ts.MatchesWon,
                            MatchesLost = ts.MatchesLost,
                            Points = ts.Points,
                            RunRate = ts.RunRate
                        }).ToList()
                    }).ToList()
                };

                _logger.LogInformation("Fetched tournament details with id {id}", id);
                return Ok(tourneyDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching tournament details with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
