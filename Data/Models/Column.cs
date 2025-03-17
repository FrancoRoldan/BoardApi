using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Column : BaseEntity
    {
        [Key]
        public int IdColumn { get; set; }

        [ForeignKey(nameof(Board))]
        [Required]
        public int IdBoard { get; set; }

        [MaxLength(100)]
        public required string Title { get; set; }
        public int Order { get; set; }

        public required virtual Board Board { get; set; }
    }
}
