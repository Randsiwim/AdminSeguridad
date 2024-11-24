using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace AdminSeguridad
{
    public partial class Permisos : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPermisos();
            }
        }

        private void CargarPermisos()
        {
            string query = "SELECT PermisoID AS ID, NombrePermiso AS Nombre FROM Permisos";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    GridViewPermisos.DataSource = reader;
                    GridViewPermisos.DataBind();
                }
            }
        }

        protected void btnNuevoPermiso_Click(object sender, EventArgs e)
        {
            HiddenFieldPermisoID.Value = string.Empty;
            txtNombrePermiso.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "showModal();", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombrePermiso = txtNombrePermiso.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombrePermiso))
                {
                    lblMensaje.Text = "El nombre del permiso es obligatorio.";
                    lblMensaje.CssClass = "error-message";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "showModal();", true);
                    return;
                }

                if (string.IsNullOrEmpty(HiddenFieldPermisoID.Value))
                {
                    // Crear nuevo permiso
                    EjecutarQuery("INSERT INTO Permisos (NombrePermiso) VALUES (@NombrePermiso)",
                        cmd => cmd.Parameters.AddWithValue("@NombrePermiso", nombrePermiso));
                }
                else
                {
                    // Editar permiso existente
                    int id = int.Parse(HiddenFieldPermisoID.Value);
                    EjecutarQuery("UPDATE Permisos SET NombrePermiso = @NombrePermiso WHERE PermisoID = @ID",
                        cmd =>
                        {
                            cmd.Parameters.AddWithValue("@NombrePermiso", nombrePermiso);
                            cmd.Parameters.AddWithValue("@ID", id);
                        });
                }

                lblMensaje.Text = "Permiso guardado correctamente.";
                lblMensaje.CssClass = "success-message";
                CargarPermisos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "error-message";
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "HideModal", "hideModal();", true);
        }

        protected void GridViewPermisos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(GridViewPermisos.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                string query = "SELECT PermisoID AS ID, NombrePermiso AS Nombre FROM Permisos WHERE PermisoID = @ID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            HiddenFieldPermisoID.Value = reader["ID"].ToString();
                            txtNombrePermiso.Text = reader["Nombre"].ToString();
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "showModal();", true);
                        }
                    }
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                EjecutarQuery("DELETE FROM Permisos WHERE PermisoID = @ID", cmd => cmd.Parameters.AddWithValue("@ID", id));
                lblMensaje.Text = "Permiso eliminado correctamente.";
                lblMensaje.CssClass = "success-message";
                CargarPermisos();
            }
        }

        private void EjecutarQuery(string query, Action<SqlCommand> configurarParametros)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    configurarParametros(command);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
