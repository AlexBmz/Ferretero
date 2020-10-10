using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaWEB.Ferretero.DataModel;

namespace SistemaWEB.Ferretero.Models
{
    public class ClienteOrden:tbCliente
    {
        public DateTime FechaOrden { get; set; }
    }
}