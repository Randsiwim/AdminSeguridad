using System;
using System.Collections.Generic;
using System.Web.UI;

namespace AdminSeguridad
{
    public partial class Menus : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Simulación de datos
                var menus = new List<object>
                {
                    new { ID = 1, Nombre = "Inicio", URL = "/Dashboard.aspx" },
                    new { ID = 2, Nombre = "Usuarios", URL = "/Usuarios.aspx" },
                    new { ID = 3, Nombre = "Roles", URL = "/Roles.aspx" }
                };

                // Asegúrate de que el control Repeater esté bien referenciado
                RepeaterMenus.DataSource = menus;
                RepeaterMenus.DataBind();
            }
        }
    }
}

