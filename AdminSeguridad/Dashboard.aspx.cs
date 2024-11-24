using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSeguridad
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer el texto del label
                LblBienvenida.Text = "¡Bienvenido al Dashboard del Sistema de Seguridad!";

                // Cargar actividades o cualquier otro dato relevante
                var actividades = new[]
                {
            new { ID = 1, Actividad = "Revisión de Seguridad", Estado = "Completada", Fecha = DateTime.Now.AddDays(-7) },
            new { ID = 2, Actividad = "Implementación de Roles", Estado = "En Proceso", Fecha = DateTime.Now }
        };

             
            }
        }
    }
}
