using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public string CodigoProducto { set; get; }
        public string NombreProducto { set; get; }
        public int Cantidad { set; get; }      
        public string Estado { set; get; }
        public DateTime Fecha { set; get; }
        public Producto()
        {
           
        }

        public Producto(string codigoProducto, string nombreProducto, int cantidad, string estado, DateTime fecha)
        {
            CodigoProducto = codigoProducto;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            Estado = estado;
            Fecha = fecha;
        }

        public override string ToString()
        {
            return $"{CodigoProducto};{NombreProducto};{Cantidad};{Estado};{Fecha}";
        }
    }
}
