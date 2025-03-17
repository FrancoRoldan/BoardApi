using Core.Security;
using Core.Services.Cards;
using Data.Dtos.Cards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Board.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cardController : ControllerBase
    {
        private readonly ILogger<boardController> _logger;
        private readonly ICardService _cardService;
        private readonly IJwtService _jwtService;
        public cardController(ILogger<boardController> logger, ICardService cardService, IJwtService jwtService)
        {
            _logger = logger;
            _cardService = cardService;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpPut("")]
        public async Task<IActionResult> UpdateCard(UpdateCardRequest req)
        {
            try
            {
                GetCardResponse? card = await _cardService.UpdateCard(req);

                if (card == null) return StatusCode(StatusCodes.Status404NotFound);

                return Ok(card);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> AddCard(AddCardRequest req)
        {
            try
            {
                GetCardResponse card = await _cardService.AddCard(req);

                return Ok(card);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
