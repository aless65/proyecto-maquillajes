﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbFacturasDetalles
    {
        public int facdet_Id { get; set; }
        public int fac_Id { get; set; }
        public int pro_Id { get; set; }
        public int facdet_Cantidad { get; set; }
        public decimal facdet_Precio { get; set; }
        public int facdet_UsuCreacion { get; set; }
        public DateTime facdet_FechaCreacion { get; set; }
        public DateTime? facdet_FechaModificacion { get; set; }
        public int? facdet_UsuModificacion { get; set; }
        public bool facdet_Estado { get; set; }

        public virtual tbFacturas fac { get; set; }
        public virtual tbUsuarios facdet_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios facdet_UsuModificacionNavigation { get; set; }
    }
}