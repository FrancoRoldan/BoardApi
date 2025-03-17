using Core.Security;
using Core.Services.Boards;
using Data.Dtos.Boards;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Board.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class boardController : ControllerBase
    {
        private readonly ILogger<boardController> _logger;
        private readonly IBoardService _boardService;
        private readonly IJwtService _jwtService;
        public boardController(ILogger<boardController> logger, IBoardService boardService, IJwtService jwtService)
        {
            _logger = logger;
            _boardService = boardService;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetAllUserBoards(int id)
        {
            try
            {
                return Ok(await _boardService.GetAllUserBoards(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> AddBoard(AddBoardRequest req)
        {
            try
            {
                string authHeader = Request.Headers.Authorization.FirstOrDefault()!;
                string token = _jwtService.ExtractTokenFromHeader(authHeader);

                User user = _jwtService.getUserFromToken(token);
                req.IdUsuario = user.Id;
                GetUserBoardsResponse board = await _boardService.AddBoard(req);

                return Ok(board);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(int id)
        {
            try
            {
                GetBoardResponse? board = await _boardService.GetBoard(id);

                if (board == null) return StatusCode(StatusCodes.Status404NotFound);

                return Ok(board);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
