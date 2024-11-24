using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace AdminSeguridad
{
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                lblError.Text = "Por favor ingrese su usuario y contraseña.";
                lblError.Visible = true;
                return;
            }

            // Validar las credenciales y obtener el rol del usuario
            int? rolUsuario = ValidarCredenciales(usuario, contrasena);

            if (rolUsuario == null)
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                lblError.Visible = true;
            }
            else
            {
                // Guardar en sesión el usuario y el rol
                Session["Usuario"] = usuario;
                Session["Rol"] = rolUsuario;

                // Redirigir según el rol
                switch (rolUsuario)
                {
                    case 1: // Administrador
                        Response.Redirect("Menus.aspx");
                        break;
                    case 2: // Usuario
                        Response.Redirect("Usuarios.aspx");
                        break;
                    case 3: // Supervisor
                        Response.Redirect("Menus.aspx");
                        break;
                    default:
                        lblError.Text = "Rol no reconocido.";
                        lblError.Visible = true;
                        break;
                }
            }
        }

        private int? ValidarCredenciales(string usuario, string contrasena)
        {
            int? rol = null;

            // Obtener la cadena de conexión desde el archivo de configuración
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string query = "SELECT RolID FROM Usuarios WHERE NombreUsuario = @usuario AND Clave = @contrasena";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        rol = Convert.ToInt32(result); // Convertir el rol a un entero
                    }
                }
            }
            return rol;
        }

    }
}




