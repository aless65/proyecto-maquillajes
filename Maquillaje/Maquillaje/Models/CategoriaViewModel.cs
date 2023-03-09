using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class CategoriaViewModel
    {
        [Display(Name = "ID")]
        public int cate_Id { get; set; }

        [Display(Name = "Nombre")]
        public string cate_Nombre { get; set; }
        public int cate_UsuCreacion { get; set; }
        public DateTime cate_FechaCreacion { get; set; }
        public int? cate_UsuModificacion { get; set; }
        public DateTime? cate_FechaModificacion { get; set; }
        public bool? cate_Estado { get; set; }
    }
}
