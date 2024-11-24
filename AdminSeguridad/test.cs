using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "data source=localhost\\Samu21\\SQLEXPRESS;initial catalog=AdministracionSeguridad;integrated security=True;trustservercertificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
            }
        }
    }
}
