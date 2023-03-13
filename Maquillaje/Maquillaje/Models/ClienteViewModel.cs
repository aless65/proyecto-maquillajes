using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "ID")]
        public int clie_Id { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string clie_Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string clie_Apellidos { get; set; }

        [Display(Name = "Identidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string clie_Identidad { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string clie_Sexo { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string muni_Id { get; set; }

        [Display(Name = "Dirección exacta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string clie_DireccionExacta { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string clie_Telefono { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string clie_CorreoElectronico { get; set; }

        public virtual tbMunicipios muni { get; set; }
    }
}
