using Integracion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Integracion
{
    public class ProductoData
    {
        private ConexionMySQL conexion = new ConexionMySQL();

        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Precio = reader.GetDecimal("precio"),
                            Stock = reader.GetInt32("stock")
                        };
                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }

        public void AddProducto(Producto producto)
        {
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO productos (nombre, precio, stock) VALUES (@nombre, @precio, @stock)", conn);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProducto(Producto producto)
        {
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE productos SET nombre = @nombre, precio = @precio, stock = @stock WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", producto.Id);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProducto(int id)
        {
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM productos WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void VenderProducto(int id, int cantidad)
        {
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE productos SET stock = stock - @cantidad WHERE id = @id AND stock >= @cantidad", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
