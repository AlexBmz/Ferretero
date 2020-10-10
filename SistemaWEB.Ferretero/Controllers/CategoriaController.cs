using SistemaWEB.Ferretero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace SistemaWEB.Ferretero.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaDAO oCatDAO = new CategoriaDAO();
        // GET: Categoria
        public ActionResult ListarCat()
        {
            List<CategoriaBEAN> listaCat = new List<CategoriaBEAN>();
            listaCat = oCatDAO.ListarCategorias();
            return View(listaCat);
        }
        [HttpGet]
        public ActionResult BusquedaCategoria()
        {
            List<CategoriaBEAN> listaCat = new List<CategoriaBEAN>();
            listaCat = oCatDAO.ListarCategorias();
            return View(listaCat);          
        }
        [HttpPost]
        public ActionResult BusquedaCategoria(int id)
        
        {          
            var list = oCatDAO.BuscarCateId(id);
            return View(list);
        }

        [HttpGet]
        public ActionResult RegistrarCategoria()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCategoria(CategoriaBEAN oCatBean)
        {
            oCatDAO.RegistrarCat(oCatBean);
            return RedirectToAction("ListarCat");
        }
        [HttpGet]
        public ActionResult EditarCategoria(int id)
        {
            CategoriaBEAN oCatBean = oCatDAO.BuscarCatId(id);
            return View(oCatBean);
        }
        [HttpPost]
        public ActionResult EditarCategoria(CategoriaBEAN oCatBean)
        {
            oCatDAO.ActualizarCategoria(oCatBean);
            return RedirectToAction ("ListarCat");
        }
    }
}