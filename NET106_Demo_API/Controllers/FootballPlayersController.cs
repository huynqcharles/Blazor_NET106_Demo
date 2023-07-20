using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET106_Demo_API.IServices;
using NET106_Demo_Shared;

namespace NET106_Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly IFootballPlayerService _footballPlayerService;

        public FootballPlayersController(IFootballPlayerService footballPlayerService)
        {
            this._footballPlayerService = footballPlayerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetFootballPlayers()
        {
            try
            {
                return Ok(await _footballPlayerService.GetFootballPlayers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FootballPlayer>> GetFootballPlayer(int id)
        {
            try
            {
                var result = await _footballPlayerService.GetFootballPlayer(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<FootballPlayer>> CreateFootballPlayer(FootballPlayer footballPlayer)
        {
            try
            {
                if (footballPlayer == null)
                {
                    return BadRequest();
                }

                var createdFootballPlayer = await _footballPlayerService.AddFootballPlayer(footballPlayer);

                return CreatedAtAction(nameof(GetFootballPlayer), new { id = createdFootballPlayer.FootballPlayerId }, createdFootballPlayer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<FootballPlayer>> UpdateFootballPlayer(FootballPlayer footballPlayer)
        {
            try
            {
                var footballPlayerToUpdate = await _footballPlayerService.GetFootballPlayer(footballPlayer.FootballPlayerId);

                if (footballPlayerToUpdate == null)
                {
                    return NotFound($"FootballPlayer with ID = {footballPlayer.FootballPlayerId} not found");
                }

                return await _footballPlayerService.UpdateFootballPlayer(footballPlayer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data from database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FootballPlayer>> DeleteFootballPlayer(int id)
        {
            try
            {
                var footballPlayerToDelete = await _footballPlayerService.GetFootballPlayer(id);

                if (footballPlayerToDelete == null)
                {
                    return NotFound($"FootballPlayer with ID = {id} not found");
                }

                return await _footballPlayerService.DeleteFootballPlayer(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data from database");
            }
        }
    }
}
