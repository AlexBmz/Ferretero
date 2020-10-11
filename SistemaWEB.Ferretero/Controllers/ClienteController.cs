using SistemaWEB.Ferretero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace SistemaWEB.Ferretero.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDAO oCliDAO = new ClienteDAO();
        ClienteBEAN oCliBean = new ClienteBEAN();
        TipoDocumentoDAO oTipoDao = new TipoDocumentoDAO();
       
        // GET: Cliente
        public ActionResult ListaClientes()
        {
            List<ClienteBEAN> ListCliBEAN = new List<ClienteBEAN>();
            ListCliBEAN = oCliDAO.ListarClientes();
            return View(ListCliBEAN);
        }
        [HttpGet]
        public ActionResult BuscarClienteByNombre()
        {
            List<ClienteBEAN> ListCliBEAN = new List<ClienteBEAN>();
            ListCliBEAN = oCliDAO.ListarClientes();
            return View(ListCliBEAN);
        }
        [HttpPost]
        public ActionResult BuscarClienteByNombre(string nomb)
        {
            var list = oCliDAO.BuscarClientePorNomb(nomb);
            return View(list);
        }
        [HttpGet]
        public ActionResult RegistrarCliente()
        {
            var doc = oTipoDao.ListarTipoDocumento().ToList();
            ViewBag.Lista = new SelectList(doc, "IdTipoDoc", "Descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarCliente(ClienteBEAN oCliBean)
        {
            if(!ModelState.IsValid)
            {
                this.RegistrarCliente();
                return View();
            }
         
            oCliDAO.RegistroClientes(oCliBean);        
            return RedirectToAction("ListaClientes");
        }

        [HttpGet]
        public ActionResult EditarCliente(int id)
        {
            ClienteBEAN oClibean = oCliDAO.BuscarClienteId(id);
            var doc = oTipoDao.ListarTipoDocumento().ToList();
            ViewBag.Lista = new SelectList(doc, "IdTipoDoc", "Descripcion");
            return View(oClibean);
        }
        [HttpPost]
        public ActionResult EditarCliente(ClienteBEAN oCliBean)
        {
            oCliDAO.ActualizarCliente(oCliBean);
            return RedirectToAction("ListaClientes");
        }
        public ActionResult EliminarCliente(int id)
        {
            oCliDAO.EliminarCliente(id);
            return RedirectToAction("ListaClientes");
        }
    }
}


