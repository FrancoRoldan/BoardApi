using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Boards
{
    public class AddBoardRequest
    {
        public int? IdBoard { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int? IdUsuario { get; set; }
    }
}
