using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class ProductoViewModel
    {
        public int prod_Id { get; set; }
        public string prod_Nombre { get; set; }
        public decimal prod_PrecioUni { get; set; }
        public int cate_Id { get; set; }
        public int prov_Id { get; set; }
        public int prod_Stock { get; set; }
        public virtual tbCategorias cate { get; set; }
        public virtual tbProveedores prov { get; set; }
    }
}
