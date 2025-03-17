
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Card : BaseEntity
    {
        [Key]
        public int IdCard { get; set; }

        [ForeignKey(nameof(ColumnBoard))]
        [Required]
        public int IdColumn { get; set; }

        [MaxLength(100)]
        public required string Title { get; set; }

        [MaxLength(100)]
        public required string Description { get; set; }

        public required int Order { get; set; }

        public required virtual Column ColumnBoard { get; set; }
    }
}
