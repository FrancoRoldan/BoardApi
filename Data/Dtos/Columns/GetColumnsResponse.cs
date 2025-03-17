using Data.Dtos.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Columns
{
    public class GetColumnsResponse
    {
        public int IdColumn { get; set; }
        public required string Title { get; set; }
        public int Order { get; set; }
        public List<GetCardResponse>? Cards { get; set; }
    }
}
