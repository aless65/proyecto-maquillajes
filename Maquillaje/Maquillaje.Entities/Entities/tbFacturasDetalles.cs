﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbFacturasDetalles
    {
        public int factdeta_Id { get; set; }
        public int fact_Id { get; set; }
        public int prod_Id { get; set; }
        public int factdeta_Cantidad { get; set; }
        public decimal factdeta_Precio { get; set; }
        public int factdeta_UsuCreacion { get; set; }
        public DateTime factdeta_FechaCreacion { get; set; }
        public DateTime? factdeta_FechaModificacion { get; set; }
        public int? factdeta_UsuModificacion { get; set; }
        public bool? factdeta_Estado { get; set; }

        public virtual tbFacturas fact { get; set; }
        public virtual tbUsuarios factdeta_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios factdeta_UsuModificacionNavigation { get; set; }
        public virtual tbProductos prod { get; set; }
    }
}