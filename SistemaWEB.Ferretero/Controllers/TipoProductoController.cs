using SistemaWEB.Ferretero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWEB.Ferretero.Controllers
{
    public class TipoProductoController : Controller
    {
        TipoProductoDAO oTipoProdDAO = new TipoProductoDAO();
        ClaseDAO oClase = new ClaseDAO();
        // GET: TipoProducto
        public ActionResult ListaTipoProductos()
        {
            List<TipoPoductoBEAN> ListaTipoProd = new List<TipoPoductoBEAN>();
            ListaTipoProd = oTipoProdDAO.ListarTipoProducto();
            return View(ListaTipoProd);
        }
        [HttpGet]
        public ActionResult RegistrarTipoProdss()
        {
            var listaTipPro = oClase.ListarClase().ToList();
            ViewBag.ListaClases= new SelectList(listaTipPro, "IdClase", "NombClase");
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarTipoProdss(TipoPoductoBEAN oTipoProd)
        {
            oTipoProdDAO.RegistrarTipoProducto(oTipoProd);
            return RedirectToAction("ListaTipoProductos");
        }
        [HttpGet]
        public ActionResult EditarTipoProd(int id)
        {
            TipoPoductoBEAN oTipoProd = oTipoProdDAO.BuscarTipoProdId(id);
            var listaTipPro = oClase.ListarClase().ToList();
            ViewBag.ListaClases = new SelectList(listaTipPro, "IdClase", "NombClase");
            return View(oTipoProd);
        }
        [HttpPost]
        public ActionResult EditarTipoProd(TipoPoductoBEAN oTipoProd)
        {
            oTipoProdDAO.ActualizarTipoProd(oTipoProd);
            return RedirectToAction("ListaTipoProductos");
        }
    }
}