using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class TipoPoductoBEAN
    {
        public int IdTipoProd { get; set; }
        public string NombreTipoProd { get; set; }
        public int IdClase { get; set; }
        public string NombreClase { get; set; }

    }
}