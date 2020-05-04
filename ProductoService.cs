using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
    public class ProductoService
    {
        ProductoRepository    repositorio = new ProductoRepository();
        
        public string Guardar(Producto producto)
        {
          
                if (repositorio.Buscar(producto.CodigoProducto)==null)
                {
                    repositorio.Guardar(producto);
                    return $"el producto {producto.CodigoProducto}, Guardo.";
                }
           
                return "Error, el producto ya existe.";
            
        }
        public List<Producto> Consultar() { return repositorio.Consultar(); }
        public Producto Buscar(string id) { return repositorio.Buscar(id); }
        public string Modificar(string NN)
        {
            if (repositorio.Buscar(NN) != null)
            {
                repositorio.Modificar(repositorio.Buscar(NN));
                return $"el producto {NN}, Se modifico.";
            }

            return "Error, el producto no existe.";

        }
    }
}
