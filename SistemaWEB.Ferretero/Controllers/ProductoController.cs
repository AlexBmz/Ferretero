using SistemaWEB.Ferretero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWEB.Ferretero.Controllers
{
    public class ProductoController : Controller
    {
        ProductoDAO oProdDAO = new ProductoDAO();
        TipoProductoDAO oTipoProdDAO = new TipoProductoDAO();
        // GET: Producto
        public ActionResult ListaProducto()
        {
            List<ProductoBEAN> ListProd = new List<ProductoBEAN>();
            ListProd = oProdDAO.ListarProductos();
            return View(ListProd);
        }
        [HttpGet]
        public ActionResult BuscarProdByNomb()
        {
            List<ProductoBEAN> list = new List<ProductoBEAN>();
            list = oProdDAO.ListarProductos();
            return View(list);
        }
        [HttpPost]
        public ActionResult BuscarProdByNomb(string nomb)
        {
           var list= oProdDAO.BuscarProductoPorNomb(nomb);
            return View(list);
        }
        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            var listaProds = oTipoProdDAO.ListarTipoProducto().ToList();
            ViewBag.ListaTipoPrd = new SelectList(listaProds, "IdTipoProd", "NombreTipoProd");
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarProducto(ProductoBEAN oProdBean)
        {
            oProdDAO.RegistrarProducto(oProdBean);
            return RedirectToAction("ListaProducto");
        }
        [HttpGet]
        public ActionResult EditarProducto(int id)
        {
            ProductoBEAN oProdBean = oProdDAO.BuscarProducto(id);
            var listaProds = oTipoProdDAO.ListarTipoProducto().ToList();
            ViewBag.ListaTipoPrd = new SelectList(listaProds, "IdTipoProd", "NombreTipoProd");
            return View(oProdBean);
        }
        [HttpPost]
        public ActionResult EditarProducto(ProductoBEAN oProd)
        {
            oProdDAO.ActualizarProducto(oProd);
            return RedirectToAction("ListaProducto");
        }
    }
}