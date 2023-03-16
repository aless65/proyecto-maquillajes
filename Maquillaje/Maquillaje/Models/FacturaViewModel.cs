﻿using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class FacturaViewModel
    {
        [Display(Name = "ID")]
        public int fact_Id { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int clie_Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime fact_Fecha { get; set; }

        [Display(Name = "Método de pago")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int meto_Id { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int empe_Id { get; set; }
        public int fact_UsuCreacion { get; set; }
        public DateTime fact_FechaCreacion { get; set; }
        public DateTime? fact_FechaModificacion { get; set; }
        public int? fact_UsuModificacion { get; set; }
        public bool? fact_Estado { get; set; }

        public virtual tbClientes clie { get; set; }

        public virtual tbEmpleados empe { get; set; }

        public virtual tbMetodosPago meto { get; set; }
        public virtual tbCategorias cate { get; set; }
    }
}
