﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Maquillaje.Entities.Entities
{
    public partial class tbCategorias
    {
        public tbCategorias()
        {
            tbProductos = new HashSet<tbProductos>();
        }

        public int cat_Id { get; set; }
        public string cat_Nombre { get; set; }
        public int cat_UsuCreacion { get; set; }
        public DateTime cat_FechaCreacion { get; set; }
        public int? cat_UsuModificacion { get; set; }
        public DateTime? cat_FechaModificacion { get; set; }
        public bool cat_Estado { get; set; }

        public virtual tbUsuarios cat_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios cat_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbProductos> tbProductos { get; set; }
    }
}