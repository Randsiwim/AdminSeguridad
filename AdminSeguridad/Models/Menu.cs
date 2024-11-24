using System.ComponentModel.DataAnnotations;

namespace AdminSeguridad.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }

        [Required, MaxLength(100)]
        public string NombreMenu { get; set; }
    }
}
