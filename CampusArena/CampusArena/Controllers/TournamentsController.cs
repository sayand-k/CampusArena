using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusArena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        [HttpGet("public-scores")]
        [AllowAnonymous] // Anyone can see this! No login needed.
        public IActionResult GetScores()
        {
            return Ok("Here are the live scores for everyone to see!");
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")] // ONLY someone with the Admin "Wristband" can enter!
        public IActionResult CreateTournament(string name)
        {
            return Ok($"Tournament '{name}' created successfully by the Admin!");
        }
    }
}