﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbSucursales
    {
        public int sucu_Id { get; set; }
        public string sucu_Descripcion { get; set; }
        public string muni_Id { get; set; }
        public string sucu_DireccionExacta { get; set; }
        public DateTime sucu_FechaCreacion { get; set; }
        public int sucu_UsuCreacion { get; set; }
        public DateTime? sucu_FechaModificacion { get; set; }
        public int? sucu_UsuModificacion { get; set; }
        public bool? sucu_Estado { get; set; }

        public virtual tbMunicipios muni { get; set; }
        public virtual tbUsuarios sucu_UsuCreacionNavigation { get; set; }
    }
}