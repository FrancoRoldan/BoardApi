using Data.Dtos.Boards;

namespace Core.Services.Boards
{
    public interface IBoardService
    {
        Task<List<GetUserBoardsResponse>> GetAllUserBoards(int idUsuario);
        Task<GetBoardResponse?> GetBoard(int idBoard);
        Task<GetUserBoardsResponse> AddBoard(AddBoardRequest board);
    }
}
