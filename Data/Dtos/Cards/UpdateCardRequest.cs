using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Cards
{
    public class UpdateCardRequest
    {
        public int IdCard { get; set; }
        public int IdColumn { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int Order { get; set; }
    }
}
