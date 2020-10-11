using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class CategoriaBEAN
    {
        public int IdCategoria { get; set; }
        [StringLength(20)]
        public string NombCat { get; set; }
        public int Estado { get; set; }
    }
}