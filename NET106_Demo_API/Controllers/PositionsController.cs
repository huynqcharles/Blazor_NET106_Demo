using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET106_Demo_API.IServices;
using NET106_Demo_Shared;

namespace NET106_Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            this._positionService = positionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPositions()
        {
            try
            {
                return Ok(await _positionService.GetPositions());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Position>> GetPosition(int id)
        {
            try
            {
                var result = await _positionService.GetPosition(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
