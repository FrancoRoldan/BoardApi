
namespace Data.Models
{
    public class BaseEntity
    {
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UsuarioCreacion { get; set; }
        public string? UsuarioModifico { get; set; }
    }
}
