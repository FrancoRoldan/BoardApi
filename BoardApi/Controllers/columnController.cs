using Core.Security;
using Core.Services.Columns;
using Data.Dtos.Columns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Board.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class columnController : ControllerBase
    {
        private readonly ILogger<boardController> _logger;
        private readonly IColumnService _columnService;
        private readonly IJwtService _jwtService;
        public columnController(ILogger<boardController> logger, IColumnService columnService, IJwtService jwtService)
        {
            _logger = logger;
            _columnService = columnService;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> AddColum(AddColumnRequest req)
        {
            try
            {
                GetColumnsResponse card = await _columnService.AddColumn(req);

                return Ok(card);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPut()]
        public async Task<IActionResult> UpdateColumn(UpdateColumnRequest req)
        {
            try
            {
                GetColumnsResponse? column = await _columnService.UpdateColumn(req);

                if (column == null) return StatusCode(StatusCodes.Status404NotFound);

                return Ok(column);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
