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
    [Authorize(Roles = "Owner")]
    public class TournamentController : ControllerBase
    {
        private readonly CricksDataContext _context;
        private readonly ILogger<TournamentController> _logger;

        public TournamentController(CricksDataContext context, ILogger<TournamentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /tournament
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tournaments = await _context.Tournaments.ToListAsync();
                _logger.LogInformation("Fetched all tournaments");
                return Ok(tournaments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching tournaments");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /tournament/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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


        // POST: /tournament
        [HttpPost]
        public async Task<IActionResult> Post(TournamentDTO tournamentDto)
        {
            try
            {
                var tournament = new Tournament
                {
                    Name = tournamentDto.Name,
                    Description = tournamentDto.Description,
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.UtcNow
                };

                _context.Tournaments.Add(tournament);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created tournament with id {id}", tournament.TournamentId);
                return CreatedAtAction(nameof(Get), new { id = tournament.TournamentId }, tournament);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating tournament");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: /tournament/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TournamentDTO tournamentDto)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                _logger.LogWarning("Tournament with id {id} not found", id);
                return NotFound();
            }

            tournament.Name = tournamentDto.Name;
            tournament.Description = tournamentDto.Description;
            tournament.ModifiedBy = User.Identity.Name;
            tournament.ModifiedDate = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Updated tournament with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating tournament with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: /tournament/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tournament = await _context.Tournaments.FindAsync(id);

                if (tournament == null)
                {
                    _logger.LogWarning("Tournament with id {id} not found", id);
                    return NotFound();
                }

                _context.Tournaments.Remove(tournament);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted tournament with id {id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting tournament with id {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
