using Data.Dtos.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Boards
{
    public class GetBoardResponse
    {
        public int IdBoard { get; set; }
        public required string Title { get; set; }
        public List<GetColumnsResponse>? Columns { get; set; }

    }
}
