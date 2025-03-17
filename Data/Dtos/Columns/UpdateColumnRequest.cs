using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Columns
{
    public class UpdateColumnRequest
    {
        public int IdBoard {  get; set; }
        public int IdColumn { get; set; }
        public string? Title { get; set; }
        public int Order { get; set; }
    }
}
