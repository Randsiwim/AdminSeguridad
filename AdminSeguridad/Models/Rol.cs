using System.ComponentModel.DataAnnotations;

namespace AdminSeguridad.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [Required, MaxLength(50)]
        public string NombreRol { get; set; }
    }
}
