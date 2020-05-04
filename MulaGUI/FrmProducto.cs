using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
namespace Mula
{
    public partial class FrmProducto : Form
    {
        Producto producto = new Producto();
        ProductoService service = new ProductoService();
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void BttGuardar_Click(object sender, EventArgs e)
        {
            producto.CodigoProducto = txtIDProducto.Text;
            producto.NombreProducto = txtNombreProducto.Text;
            producto.Cantidad = int.Parse( txtCantidad.Text);
            producto.Estado = txtEstado.Text;
            producto.Fecha = CalendarioSkill.Value.Date;
            string mensaje = service.Guardar(producto);
            MessageBox.Show(mensaje, "Guardo");

        }

        private void BttConsultar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.Consultar();
        }

        private void BttRegreso_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
