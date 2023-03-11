using Maquillaje.Entities.Entities;
    using System;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
    using System.Threading.Tasks;

    namespace Maquillaje.WebUI.Models
    {
        public class EmpleadoViewModel
        {
            public int empe_Id { get; set; }

            [Display(Name = "Nombres")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public string empe_Nombres { get; set; }

            [Display(Name = "Apellidos")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public string empe_Apellidos { get; set; }

            [Display(Name = "Número de identidad")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public string empe_Identidad { get; set; }

            [Display(Name = "Fecha de nacimiento")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public DateTime empe_FechaNacimiento { get; set; }

            [Display(Name = "Sexo")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public string empe_Sexo { get; set; }

            [Display(Name = "Estado civil")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public int estacivi_Id { get; set; }

            [Display(Name = "Municipio")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public string muni_Id { get; set; }

            [Display(Name = "Dirección exacta")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public string empe_Direccion { get; set; }

            [Display(Name = "Número de teléfono")]
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public string empe_Telefono { get; set; }

            [Display(Name = "Correo electrónico")]
            public string empe_CorreoElectronico { get; set; }
            public int empe_UsuCreacion { get; set; }
            public DateTime empe_FechaCreacion { get; set; }
            public int? empe_UsuModificacion { get; set; }
            public DateTime? empe_FechaModificacion { get; set; }
            public bool? empe_Estado { get; set; }

            public virtual tbUsuarios empe_UsuCreacionNavigation { get; set; }
            public virtual tbUsuarios empe_UsuModificacionNavigation { get; set; }
            public virtual tbEstadosCiviles estacivi { get; set; }
            public virtual tbMunicipios muni { get; set; }
            public virtual ICollection<tbUsuarios> tbUsuarios { get; set; }
        }
    }
