using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace AdminSeguridad.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required, MaxLength(50)]
        public string NombreUsuario { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string NombreCompleto { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        [Required]
        public string Clave { get; set; }

        [ForeignKey("Rol")]
        public int RolID { get; set; }
        public Rol Rol { get; set; }
    }
}
