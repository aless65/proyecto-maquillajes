using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class FacturaDetalleViewModel
    {
        [Display(Name = "ID")]
        public int factdeta_Id { get; set; }

        [Display(Name = "Factura")]
        public int fact_Id { get; set; }

        [Display(Name = "Factura")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int prod_Id { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int factdeta_Cantidad { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal factdeta_Precio { get; set; }
        public int factdeta_UsuCreacion { get; set; }
        public DateTime factdeta_FechaCreacion { get; set; }
        public DateTime? factdeta_FechaModificacion { get; set; }
        public int? factdeta_UsuModificacion { get; set; }
        public bool? factdeta_Estado { get; set; }
    }
}
