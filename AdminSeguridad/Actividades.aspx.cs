using System;
using System.Collections.Generic;
using System.Web.UI;

namespace AdminSeguridad
{
    public partial class Actividades : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Simulación de datos
                var actividades = new List<object>
                {
                    new { ID = 1, Nombre = "Revisión de Seguridad", Estado = "Completada", FechaInicio = DateTime.Now.AddDays(-7), FechaFin = DateTime.Now.AddDays(-1) },
                    new { ID = 2, Nombre = "Implementación de Roles", Estado = "En Proceso", FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(5) }
                };

                GridViewActividades.DataSource = actividades;
                GridViewActividades.DataBind();
            }
        }
    }
}
