using System;
using MySql.Data.MySqlClient;

public class Program
{
    public static void Main()
    {
        string server = "127.0.0.1:3306";        // Cambia esto por tu servidor de MySQL
        string database = "integracion";      // Cambia esto por tu base de datos
        string username = "jocel";     // Cambia esto por tu nombre de usuario de MySQL
        string password = "";  // Cambia esto por tu contraseña de MySQL

        GestorConexion gestorConexion = new GestorConexion(server, database, username, password);
        MySqlConnection conexion = gestorConexion.ObtenerConexion();

        try
        {
            conexion.Open();
            Console.WriteLine("Conexión establecida correctamente.");

            // Aquí puedes realizar operaciones con la conexión (consultas, actualizaciones, etc.)

            conexion.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
        }
        finally
        {
            gestorConexion.Desconectar();
        }
    }
}
