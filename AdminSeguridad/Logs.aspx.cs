using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace AdminSeguridad
{
    public partial class Logs : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLogs();
            }
        }

        private void CargarLogs()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "SELECT ID, Usuario, Accion AS Acción, FechaHora FROM Logs";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable logs = new DataTable();
                    adapter.Fill(logs);

                    GridViewLogs.DataSource = logs;
                    GridViewLogs.DataBind();
                }
            }
        }
    }
}

