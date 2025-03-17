using Data.Dtos.Boards;
using Data.Dtos.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Columns
{
    public interface IColumnService
    {
        Task<GetColumnsResponse> AddColumn(AddColumnRequest column);
        Task<GetColumnsResponse?> UpdateColumn(UpdateColumnRequest column);
    }
}
