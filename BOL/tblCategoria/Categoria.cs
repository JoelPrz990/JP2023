using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public String descripcion { get; set; }
        public bool activo { get; set; }
        public Categoria() { }
    }
}
