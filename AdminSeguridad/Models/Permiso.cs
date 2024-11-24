using System.ComponentModel.DataAnnotations;

namespace AdminSeguridad.Models
{
    public class Permiso
    {
        [Key]
        public int PermisoID { get; set; }

        [Required, MaxLength(100)]
        public string NombrePermiso { get; set; }
    }
}
