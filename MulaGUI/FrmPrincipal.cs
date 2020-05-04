using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace Mula
{
    public partial class FrmPrincipal : Form
    {
        List<Producto> productos = new List<Producto>();
        ProductoService service = new ProductoService();
        Producto producto = new Producto();
        public FrmPrincipal()
        {
            InitializeComponent();
            txtProducto.Focus();    
        }
        List<string> comp = new List<string>();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            comp.Add("lollllll");
            comp.Add("lol");
            comp.Add("baaaaaaaaaaaaa");
            comp.Add("uuuuuuu");
            foreach (var item in productos)
            {
                listBox1.Items.Add(item.NombreProducto);
            }
            
        }
        
        void Cerrar() 
        {
           Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

   

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void LbCantidad_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (true)
            {

            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
        
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
           
            AutoCompleteStringCollection colecion = new AutoCompleteStringCollection();
            foreach (var item in productos)
            {
                colecion.Add(item.NombreProducto);
            }
            txtProducto.AutoCompleteCustomSource = colecion;
            txtProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            
            
             
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                LbCantidad.Text = "N° 3";
            }
        }

        private void obsionesDeProduductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.ShowDialog();
        }

        private void bttSale_Click(object sender, EventArgs e)
        {
            producto.Estado = "Sales";
            producto.Cantidad = producto.Cantidad - int.Parse(txtCantidad.Text);
            string mensaje =service.Modificar(txtProducto.Text);
            MessageBox.Show(mensaje, "Modifico");
        }

        private void bttEntra_Click(object sender, EventArgs e)
        {

            producto.Estado = "Entra";
            producto.Cantidad = producto.Cantidad + int.Parse(txtCantidad.Text);
            string mensaje = service.Modificar(txtProducto.Text);
            MessageBox.Show(mensaje, "Modifico");
        }
    }
}
