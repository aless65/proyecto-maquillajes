﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbProveedores
    {
        public tbProveedores()
        {
            tbProductos = new HashSet<tbProductos>();
        }

        public int prov_Id { get; set; }
        public string prov_Nombre { get; set; }
        public string prov_CorreoElectronico { get; set; }
        public string prov_Telefono { get; set; }
        public int prov_UsuCreacion { get; set; }
        public DateTime prov_FechaCreacion { get; set; }
        public int? prov_UsuModificacion { get; set; }
        public DateTime? prov_FechaModificacion { get; set; }
        public bool? prov_Estado { get; set; }

        public virtual tbUsuarios prov_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios prov_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbProductos> tbProductos { get; set; }
    }
}