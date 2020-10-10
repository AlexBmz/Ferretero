using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaWEB.Ferretero.DataModel;
using System.Web.Mvc;
using SistemaWEB.Ferretero.Models;

namespace SistemaWEB.Ferretero.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult NuevaVenta()
        {
            VentaView oVentaView = new VentaView();
            oVentaView.Cliente = new ClienteOrden();
            oVentaView.Productos = new List<ProductoOrden>();

            return View(oVentaView);
        }
    }
}