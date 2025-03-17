using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Boards
{
    public class GetUserBoardsResponse
    {
        public int IdBoard { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
