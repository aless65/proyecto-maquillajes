﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbFacturas
    {
        public tbFacturas()
        {
            tbFacturasDetalles = new HashSet<tbFacturasDetalles>();
        }

        public int fac_Id { get; set; }
        public int cli_Id { get; set; }
        public DateTime fac_Fecha { get; set; }
        public int met_Id { get; set; }
        public int emp_Id { get; set; }
        public int fac_UsuCreacion { get; set; }
        public DateTime fac_FechaCreacion { get; set; }
        public DateTime? fac_FechaModificacion { get; set; }
        public int? fac_UsuModificacion { get; set; }
        public bool fac_Estado { get; set; }

        public virtual tbClientes cli { get; set; }
        public virtual tbUsuarios fac_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios fac_UsuModificacionNavigation { get; set; }
        public virtual tbMetodosPago met { get; set; }
        public virtual ICollection<tbFacturasDetalles> tbFacturasDetalles { get; set; }
    }
}