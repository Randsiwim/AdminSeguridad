using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace AdminSeguridad // Asegúrate de que este coincida con el namespace de tu proyecto
{
    public partial class Usuarios : Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        // Método para cargar usuarios en el GridView
        private void CargarUsuarios()
        {
            string query = "SELECT UsuarioID, NombreUsuario, RolID, Email, NombreCompleto, Telefono, Direccion FROM Usuarios";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    GridViewUsuarios.DataSource = reader;
                    GridViewUsuarios.DataBind();
                }
            }
        }




        // Evento del botón "Guardar"
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text.Trim();
            string rol = TxtRol.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string nombreCompleto = TxtNombreCompleto.Text.Trim();
            string clave = TxtClave.Text.Trim();
            string telefono = TxtTelefono.Text.Trim();
            string direccion = TxtDireccion.Text.Trim();

            // Validar campos
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(rol) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(nombreCompleto) ||
                string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(direccion))
            {
                LblError.Text = "Todos los campos son obligatorios.";
                return;
            }

            if (string.IsNullOrEmpty(HdnIDUsuario.Value))
            {
                // Inserción
                string query = "INSERT INTO Usuarios (NombreUsuario, RolID, Email, NombreCompleto, Clave, Telefono, Direccion) " +
                               "VALUES (@NombreUsuario, @RolID, @Email, @NombreCompleto, @Clave, @Telefono, @Direccion)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", usuario);
                        command.Parameters.AddWithValue("@RolID", rol);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                        command.Parameters.AddWithValue("@Clave", clave);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                // Actualización
                int usuarioID = int.Parse(HdnIDUsuario.Value);
                string query = "UPDATE Usuarios SET NombreUsuario = @NombreUsuario, RolID = @RolID, Email = @Email, " +
                               "NombreCompleto = @NombreCompleto, Clave = @Clave, Telefono = @Telefono, Direccion = @Direccion " +
                               "WHERE UsuarioID = @UsuarioID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", usuario);
                        command.Parameters.AddWithValue("@RolID", rol);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                        command.Parameters.AddWithValue("@Clave", clave);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            LimpiarCampos();
            CargarUsuarios();
        }




        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            TxtUsuario.Text = string.Empty;
            TxtRol.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtNombreCompleto.Text = string.Empty;
            TxtClave.Text = string.Empty; // Limpiar campo Clave
            HdnIDUsuario.Value = string.Empty;
            LblError.Text = string.Empty;
        }

        // Manejo de comandos del GridView (Editar y Eliminar)
        protected void GridViewUsuarios_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int usuarioID = Convert.ToInt32(GridViewUsuarios.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                string query = "SELECT UsuarioID, NombreUsuario, RolID, Email, NombreCompleto, Clave, Telefono, Direccion FROM Usuarios WHERE UsuarioID = @UsuarioID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            HdnIDUsuario.Value = reader["UsuarioID"].ToString();
                            TxtUsuario.Text = reader["NombreUsuario"].ToString();
                            TxtRol.Text = reader["RolID"].ToString();
                            TxtEmail.Text = reader["Email"].ToString();
                            TxtNombreCompleto.Text = reader["NombreCompleto"].ToString();
                            TxtClave.Text = reader["Clave"].ToString();
                            TxtTelefono.Text = reader["Telefono"].ToString();
                            TxtDireccion.Text = reader["Direccion"].ToString();
                        }
                    }
                }
            }

            else if (e.CommandName == "Eliminar")
            {
                string query = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                CargarUsuarios();
            }
        }
    }
}

