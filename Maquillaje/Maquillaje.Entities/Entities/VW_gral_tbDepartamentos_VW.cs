﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class VW_gral_tbDepartamentos_VW
    {
        [Display(Name = "ID")]
        public string depa_Id { get; set; }
        [Display(Name = "Departamento")]
        public string depa_Nombre { get; set; }
        [Display(Name = "Usuario Creacion ID")]
        public int depa_UsuCreacion { get; set; }
        [Display(Name = "Usuario Creacion")]
        public string depe_UsuCreacion_Nombre { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime depa_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion ID")]
        public int? depa_UsuModificacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public string depa_UsuModificacion_Nombre { get; set; }
        [Display(Name = "Fecha Modificacion")]
        public DateTime? depa_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool depa_Estado { get; set; }
    }
}