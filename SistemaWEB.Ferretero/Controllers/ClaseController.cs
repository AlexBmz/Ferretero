using SistemaWEB.Ferretero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWEB.Ferretero.Controllers
{
    public class ClaseController : Controller
    {
        ClaseDAO oClasDAO = new ClaseDAO();
        CategoriaDAO oCatDAO = new CategoriaDAO();
        // GET: Clase
        public ActionResult ListaClase()
        {
            List<ClaseBEAN> listClase = new List<ClaseBEAN>();
            listClase = oClasDAO.ListarClase();
            return View(listClase);
        }

        [HttpGet]
        public ActionResult RegistrarClase()
        {
            var listcat = oCatDAO.ListarCategorias().ToList();
            ViewBag.ListaClase = new SelectList(listcat, "IdCategoria", "NombCat");
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarClase(ClaseBEAN oClase)
        {
            oClasDAO.RegistrarClase(oClase);
            return RedirectToAction("ListaClase");
        }
        [HttpGet]
        public ActionResult EditarClase(int id)
        {
            ClaseBEAN oClaseBean = oClasDAO.BuscarClaseId(id);
            var listcat = oCatDAO.ListarCategorias().ToList();
            ViewBag.ListaClase = new SelectList(listcat, "IdCategoria", "NombCat");
            return View(oClaseBean);
        }
        [HttpPost]
        public ActionResult EditarClase(ClaseBEAN oClaseBean)
        {
            oClasDAO.ActualizarCategoria(oClaseBean);
            return RedirectToAction("ListaClase");
        }
    }
}