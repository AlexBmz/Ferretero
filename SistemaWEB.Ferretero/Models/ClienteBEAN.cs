using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class ClienteBEAN
    {
        public int IdCliente { get; set; }

        [Required]
        public string NombreCliente { get; set; }

        [Required]
        public String ApePat { get; set; }

        [Required]
        public string ApeMat { get; set; }

        public string Direccion { get; set; }
       
        public int Telefono { get; set; }

        public String Email { get; set; }
        public int  IdTipoDoc { get; set; }
        public int  Documento { get; set; }
        public string Descripcion { get; set; }
    }
}