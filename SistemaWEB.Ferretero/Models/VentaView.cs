using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaWEB.Ferretero.DataModel;
namespace SistemaWEB.Ferretero.Models
{
    public class VentaView
    {
        public ClienteOrden Cliente { get; set; }
        public tbVentaDetalle Titulos { get; set; }
        public List<ProductoOrden> Productos { get; set; }
    }
}