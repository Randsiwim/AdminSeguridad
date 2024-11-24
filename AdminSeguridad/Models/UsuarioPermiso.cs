using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminSeguridad.Models
{
    public class UsuarioPermiso
    {
        [Key, Column(Order = 0)]
        public int UsuarioID { get; set; }

        [Key, Column(Order = 1)]
        public int PermisoID { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; }

        [ForeignKey("PermisoID")]
        public Permiso Permiso { get; set; }
    }
}
