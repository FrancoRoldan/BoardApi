using Data.Dtos.Columns;
using Data.Interfaces;
using Data.Models;
using Mapster;

namespace Core.Services.Columns
{
    public class ColumnService:IColumnService
    {
        private readonly IColumnRepository _columnRepository;

        public ColumnService(IColumnRepository columnBoardRepository)
        {
            _columnRepository = columnBoardRepository;
        }
        public async Task<GetColumnsResponse?> UpdateColumn(UpdateColumnRequest req)
        {
            Column? column = await _columnRepository.GetByIdAsync(req.IdColumn);

            if (column == null) return null;

            List<Column> columns = await _columnRepository.GetByIdBoard(req.IdBoard);
            List<Column> otherColumns = columns.Where(c => c.IdColumn != req.IdColumn).ToList();

            int oldOrder = column.Order;
            int newOrder = Math.Min(Math.Max(1, req.Order), otherColumns.Count + 1);

            foreach (var otherColumn in otherColumns)
            {
                if (oldOrder < newOrder)
                {
                    if (otherColumn.Order > oldOrder && otherColumn.Order <= newOrder)
                    {
                        otherColumn.Order -= 1;
                        await _columnRepository.UpdateAsync(otherColumn);
                    }
                }
                else if (oldOrder > newOrder)
                {
                    if (otherColumn.Order >= newOrder && otherColumn.Order < oldOrder)
                    {
                        otherColumn.Order += 1;
                        await _columnRepository.UpdateAsync(otherColumn);
                    }
                }
            }

            if (!string.IsNullOrEmpty(req.Title))
                column.Title = req.Title;

            column.Order = req.Order;

            await _columnRepository.UpdateAsync(column);
            return column.Adapt<GetColumnsResponse>();
        }

        public async Task<GetColumnsResponse> AddColumn(AddColumnRequest column)
        {
            List<Column> existingColumns = await _columnRepository.GetByIdBoard(column.IdBoard);
            column.Order = existingColumns.Count > 0 ? existingColumns.Max(c => c.Order) + 1 : 1;

            var newColumn = await _columnRepository.AddAsync(column.Adapt<Column>());

            return newColumn.Adapt<GetColumnsResponse>();
        }
    }
}
