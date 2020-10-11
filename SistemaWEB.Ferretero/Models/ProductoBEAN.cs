using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWEB.Ferretero.Models
{
    public class ProductoBEAN
    {
        public int IdProducto { get; set; }
        [Required]
        public string NombreProd { get; set; }
        [Required]
        public Decimal PrecioProd { get; set; }
        [Required]
        public int Stock { get; set; }
        public int IdTipoProd { get; set; }
        public string NombTipoProd { get; set; }
    }
}