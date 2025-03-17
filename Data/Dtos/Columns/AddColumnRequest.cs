using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Columns
{
    public class AddColumnRequest
    {
        public int IdBoard {  get; set; }
        public required string Title { get; set; }
        public int? Order { get; set; }
        public DateTime? fechaCreado { get; set; } = DateTime.Now;
    }
}
