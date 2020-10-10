using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaWEB.Ferretero.DataModel;

namespace SistemaWEB.Ferretero.Models
{
    public class ProductoOrden:tbProducto
    {
        public int Cantidades { get; set; }
        public decimal Valor { get { return PrecioUnit * Cantidades; } }
    }
}