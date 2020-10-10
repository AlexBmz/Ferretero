using SistemaWEB.Ferretero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWEB.Ferretero.Controllers
{
    public class TipoDocumentoController : Controller
    {
        TipoDocumentoDAO oTipoDocDAO = new TipoDocumentoDAO();
        // GET: TipoDocumento
        public ActionResult ListarTipoDoc()
        {
            List<TipoDocumentoBEAN> ListTipoBEAN = new List<TipoDocumentoBEAN>();
            ListTipoBEAN = oTipoDocDAO.ListarTipoDocumento();
            return View(ListTipoBEAN);
        }
        
        [HttpGet]
        public ActionResult RegistrarTipoDoc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarTipoDoc(TipoDocumentoBEAN oTipoDocBean)
        {
            oTipoDocDAO.RegistroTipoDoc(oTipoDocBean);
            return RedirectToAction("ListarTipoDoc");
        }
        [HttpGet]
        public ActionResult EditarTipoDoc(int id)
        {
            TipoDocumentoBEAN oTipoBean = oTipoDocDAO.BuscarTipoDocId(id);
            return View(oTipoBean);
        }
        [HttpPost]
        public ActionResult EditarTipoDoc(TipoDocumentoBEAN oTipoBean)
        {
            oTipoDocDAO.ActualizarTipoDoc(oTipoBean);
           
            return RedirectToAction("ListarTipoDoc");
        }
    }
}