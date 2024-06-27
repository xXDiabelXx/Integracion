using Integracion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Integracion
{
    public partial class Form1 : Form
    {
        private ProductoData productoData = new ProductoData();

        public Form1()
        {
            InitializeComponent();
            LoadProductos();
        }

        private void LoadProductos()
        {
            List<Producto> productos = productoData.GetProductos();
            dataGridProductos.DataSource = productos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text)
            };

            productoData.AddProducto(producto);
            LoadProductos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text)
            };

            productoData.UpdateProducto(producto);
            LoadProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            productoData.DeleteProducto(id);
            LoadProductos();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            int cantidad = int.Parse(txtStock.Text);
            productoData.VenderProducto(id, cantidad);
            LoadProductos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


