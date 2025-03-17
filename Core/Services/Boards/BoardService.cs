using Data.Dtos.Boards;
using Data.Dtos.Cards;
using Data.Dtos.Columns;
using Data.Interfaces;
using Data.Models;
using Mapster;

namespace Core.Services.Boards
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IColumnRepository _columnRepository;
        private readonly ICardRepository _cardRepository;

        public BoardService(IBoardRepository boardRepository, IColumnRepository columnBoardRepository, ICardRepository cardColumnRepository)
        {
            _boardRepository = boardRepository;
            _columnRepository = columnBoardRepository;
            _cardRepository = cardColumnRepository;
        }

        public async Task<List<GetUserBoardsResponse>> GetAllUserBoards(int idUsuario)
        {
            List<Board> boards = await _boardRepository.GetByIdUsuario(idUsuario);
            return boards.Adapt<List<GetUserBoardsResponse>>();
        }

        public async Task<GetBoardResponse?> GetBoard(int idBoard)
        {
            Board? boardModel = await _boardRepository.GetByIdAsync(idBoard);

            if ( boardModel == null) return null;

            GetBoardResponse board = boardModel.Adapt<GetBoardResponse>();

            List<Column> columnBoards = await _columnRepository.GetByIdBoard(board.IdBoard);
            List<GetColumnsResponse> columns = columnBoards.Adapt<List<GetColumnsResponse>>();
            columns = columns.OrderBy(c => c.Order).ToList();

            foreach (var column in columns) {
                List<Card> cardColumns = await _cardRepository.GetByIdColumna(column.IdColumn);
                List<GetCardResponse> cards = cardColumns.Adapt<List<GetCardResponse>>();
                column.Cards = cards.OrderBy(x => x.Order).ToList();
            }

            board.Columns = columns;

            return board;
        }

        
        public async Task<GetUserBoardsResponse> AddBoard(AddBoardRequest board)
        {
            var newBoard = await _boardRepository.AddAsync(board.Adapt<Data.Models.Board>());

            return newBoard.Adapt<GetUserBoardsResponse>();
        }
    }
}
