using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
namespace DAL
{
    public class ProductoRepository
    {
        List<Producto> productos;
        public ProductoRepository()
        {
            productos = new List<Producto>();
        }
        string ruta=@"MULA.txt";
        public void Guardar(Producto producto)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(producto.ToString());
            streamWriter.Close();
            fileStream.Close();
        }
        public List<Producto> Consultar()
        {
            List<Producto> productos = new List<Producto>();
            FileStream stream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(stream);
            string linea = string.Empty;
            while ((linea =reader.ReadLine())!=null)
            {
                Producto producto = Map(linea);
                productos.Add(producto);
            }
            stream.Close();
            reader.Close();
            return productos;
        }
        public Producto Map(string linea)
        {
            string[] datos = linea.Split(';');
            Producto producto = new Producto();
            producto.CodigoProducto = datos[0];
            producto.NombreProducto = datos[1];
            producto.Cantidad = int.Parse( datos[2]);
            producto.Estado = datos[3];
            producto.Fecha = DateTime.Parse( datos[4]);
            return producto;
        }
        public Producto Buscar(string id) { return productos.Find(P => P.NombreProducto.Equals(id)); }

        public void Modificar(Producto producto)
        {
            productos.Clear();
            productos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in productos)
            {
                if (item.NombreProducto != producto.NombreProducto)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(producto);
                }
            }
        }
    }
}
