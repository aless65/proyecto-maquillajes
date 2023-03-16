using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Models
{
    public class VW_acce_tbUsuarios_ViewModel
    {
        public int user_Id { get; set; }
        public string user_NombreUsuario { get; set; }
        public string user_Contrasena { get; set; }
        public bool user_EsAdmin { get; set; }
        public int? role_Id { get; set; }
        public string role_Nombre { get; set; }
        public int? empe_Id { get; set; }
        public string empe_NombreCompleto { get; set; }
        public int? user_UsuCreacion { get; set; }
        public string user_UsuCreacion_Nombre { get; set; }
        public DateTime user_FechaCreacion { get; set; }
        public int? user_UsuModificacion { get; set; }
        public string user_UsuModificacion_Nombre { get; set; }
        public DateTime? user_FechaModificacion { get; set; }
        public bool user_Estado { get; set; }
    }
}
