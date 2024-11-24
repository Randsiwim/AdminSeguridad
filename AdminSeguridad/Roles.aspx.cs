using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace AdminSeguridad
{
    public partial class Roles : Page
    {
        // Cadena de conexión
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();
            }
        }

        // Método para cargar los roles en el GridView
        private void CargarRoles()
        {
            string query = "SELECT RolID, NombreRol FROM Roles";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    GridViewRoles.DataSource = reader;
                    GridViewRoles.DataBind();
                }
            }
        }

        // Evento para el botón "Crear Nuevo Rol"
        protected void btnNuevoRol_Click(object sender, EventArgs e)
        {
            // Mostrar formulario para crear nuevo rol
            HiddenFieldRolID.Value = string.Empty;
            txtNombreRol.Text = string.Empty;
            PanelForm.Visible = true;
        }

        // Evento para el botón "Guardar"
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreRol = txtNombreRol.Text.Trim();
            if (string.IsNullOrEmpty(nombreRol))
            {
                // Validar que no esté vacío
                return;
            }

            if (string.IsNullOrEmpty(HiddenFieldRolID.Value))
            {
                // Crear nuevo rol
                string query = "INSERT INTO Roles (NombreRol) VALUES (@NombreRol)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreRol", nombreRol);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                // Editar rol existente
                int id = int.Parse(HiddenFieldRolID.Value);
                string query = "UPDATE Roles SET NombreRol = @NombreRol WHERE RolID = @ID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreRol", nombreRol);
                        command.Parameters.AddWithValue("@ID", id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            PanelForm.Visible = false;
            CargarRoles();
        }

        // Evento para el botón "Cancelar"
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelForm.Visible = false;
        }

        // Evento para los botones del GridView (Editar y Eliminar)
        protected void GridViewRoles_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            // Obtener el índice de la fila desde el CommandArgument
            int index = Convert.ToInt32(e.CommandArgument);

            // Asegúrate de que la fila está dentro del rango válido
            if (index >= 0 && index < GridViewRoles.Rows.Count)
            {
                // Obtener el ID desde la propiedad DataKeys
                int id = Convert.ToInt32(GridViewRoles.DataKeys[index].Value);

                if (e.CommandName == "Editar")
                {
                    // Cargar datos del rol para edición
                    string query = "SELECT RolID, NombreRol FROM Roles WHERE RolID = @RolID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@RolID", id);
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                HiddenFieldRolID.Value = reader["RolID"].ToString();
                                txtNombreRol.Text = reader["NombreRol"].ToString();
                                PanelForm.Visible = true;
                            }
                        }
                    }
                }
                else if (e.CommandName == "Eliminar")
                {
                    // Eliminar rol
                    string query = "DELETE FROM Roles WHERE RolID = @RolID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@RolID", id);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    CargarRoles(); // Recargar los roles
                }

            }

        }

    }
}

