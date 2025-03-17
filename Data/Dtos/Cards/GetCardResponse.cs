using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Cards
{
    public class GetCardResponse
    {
        public int IdCard { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int Order { get; set; }
    }
}
