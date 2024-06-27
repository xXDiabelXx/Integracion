using MySql.Data.MySqlClient;

public class GestorConexion
{
    private string server;
    private string database;
    private string username;
    private string password;
    private MySqlConnection conexion;

    public GestorConexion(string server, string database, string username, string password)
    {
        this.server = server;
        this.database = database;
        this.username = username;
        this.password = password;
    }

    public void Conectar()
    {
        string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        conexion = new MySqlConnection(connectionString);
    }

    public MySqlConnection ObtenerConexion()
    {
        if (conexion == null)
        {
            Conectar();
        }
        return conexion;
    }

    public void Desconectar()
    {
        if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
        {
            conexion.Close();
        }
    }
}
