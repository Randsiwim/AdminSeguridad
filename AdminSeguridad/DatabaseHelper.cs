using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdminSeguridad
{
    public class DatabaseHelper
    {
        // Método para obtener la conexión a la base de datos
        public static SqlConnection ObtenerConexion()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la conexión: " + ex.Message);
            }
        }

        // Método para obtener usuarios desde la base de datos
        public static DataTable ObtenerUsuarios()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Usuario, Rol FROM Usuarios"; // Ajusta la consulta 
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los usuarios: " + ex.Message);
                }
            }
            return dt;
        }

        // Método para agregar un nuevo usuario
        public static void AgregarUsuario(string usuario, string rol)
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Usuarios (Usuario, Rol) VALUES (@Usuario, @Rol)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Rol", rol);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el usuario: " + ex.Message);
                }
            }
        }

        // Método para editar un usuario
        public static void EditarUsuario(int id, string usuario, string rol)
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Usuarios SET Usuario = @Usuario, Rol = @Rol WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Rol", rol);
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al editar el usuario: " + ex.Message);
                }
            }
        }

        // Método para eliminar un usuario
        public static void EliminarUsuario(int id)
        {
            using (SqlConnection connection = ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Usuarios WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el usuario: " + ex.Message);
                }
            }
        }
    }
}
