﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbClientes
    {
        public tbClientes()
        {
            tbFacturas = new HashSet<tbFacturas>();
        }

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
        public int clie_UsuCreacion { get; set; }
        public DateTime clie_FechaCreacion { get; set; }
        public int? clie_UsuModificacion { get; set; }
        public DateTime? clie_FechaModificacion { get; set; }
        public bool? clie_Estado { get; set; }

        public virtual tbUsuarios clie_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios clie_UsuModificacionNavigation { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public virtual tbMunicipios depa_Id { get; set; }
        public virtual ICollection<tbFacturas> tbFacturas { get; set; }
    }
}