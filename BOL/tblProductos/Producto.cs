using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Producto
    {
        public int IdProductos { get; set; }
        public string descripcion { get; set; }
        public int IdCategoriaFK { get; set; }
        public decimal precioUnitario { get; set; }
        public int stock { get; set; }
        public string codigo { get; set; }
        public int IdMarcaFK { get; set; }
        public bool activo { get; set; }
        public Producto() { }
    }
}
