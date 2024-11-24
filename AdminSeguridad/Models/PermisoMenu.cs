using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminSeguridad.Models
{
    public class PermisoMenu
    {
        [Key, Column(Order = 0)]
        public int MenuID { get; set; }

        [Key, Column(Order = 1)]
        public int PermisoID { get; set; }

        public bool PermisoLectura { get; set; }
        public bool PermisoEscritura { get; set; }
        public bool PermisoModificacion { get; set; }
        public bool PermisoEliminacion { get; set; }

        [ForeignKey("MenuID")]
        public Menu Menu { get; set; }

        [ForeignKey("PermisoID")]
        public Permiso Permiso { get; set; }
    }
}
