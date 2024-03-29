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
        public string clie_Nombres { get; set; }
        [Display(Name = "Apellidos")]
        public string clie_Apellidos { get; set; }
        [Display(Name = "Identidad")]
        public string clie_Identidad { get; set; }
        [Display(Name = "Sexo")]
        public string clie_Sexo { get; set; }
        [Display(Name = "Municipio")]
        public string muni_Id { get; set; }
        [Display(Name = "Direccion Exacta")]
        public string clie_DireccionExacta { get; set; }
        [Display(Name = "Telefono")]
        public string clie_Telefono { get; set; }
        [Display(Name = "Correo Electronico")]
        public string clie_CorreoElectronico { get; set; }
        [Display(Name = "Usuario Creacion")]
        public int clie_UsuCreacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime clie_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public int? clie_UsuModificacion { get; set; }
        [Display(Name = "Fecha Modificacion")]
        public DateTime? clie_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool? clie_Estado { get; set; }

        public virtual tbUsuarios clie_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios clie_UsuModificacionNavigation { get; set; }
        [Display(Name = "Departamento")]
        public virtual tbMunicipios depa_Id { get; set; }
        public virtual ICollection<tbFacturas> tbFacturas { get; set; }
    }
}