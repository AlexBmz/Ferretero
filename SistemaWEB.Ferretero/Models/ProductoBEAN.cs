using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class ProductoBEAN
    {
        public int IdProducto { get; set; }
        public string NombreProd { get; set; }
        public Decimal PrecioProd { get; set; }
        public int Stock { get; set; }
        public int IdTipoProd { get; set; }
        public string NombTipoProd { get; set; }
    }
}