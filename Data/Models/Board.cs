using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Board : BaseEntity
    {
        [Key]
        public int IdBoard { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public int IdUsuario { get; set; }

        [MaxLength(100)]
        public required string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public required virtual User User { get; set; }
    }
}
