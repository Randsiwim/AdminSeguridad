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
                
                LblBienvenida.Text = "¡Bienvenido al Dashboard del Sistema de Seguridad!";

                
              

             
            }
        }
    }
}
