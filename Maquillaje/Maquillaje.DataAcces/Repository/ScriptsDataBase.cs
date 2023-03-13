using System;
using System.Collections.Generic;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class ScriptsDataBase
    {
        #region Categorías
        public static string UDP_Listar_Categorias = "UDP_maqu_tbCategorias_List";

        public static string UDP_Insertar_Categorias = "UDP_maqu_tbCategorias_INSERT";
        #endregion

        #region Empleados
        public static string UDP_Listar_Empleado = "maqu.UDP_maqu_tbEmpleados_List";
        public static string UDP_Insertar_Empleado = "maqu.UPD_maqu_tbEmpleados_Insert";
        public static string UDP_Editar_Empleado = "maqu.UDP_maqu_tbEmpleados_Update";
        public static string UDP_Eliminar_Empleado = "maqu.UDP_maqu_tbEmpleados_Delete";
        #endregion

        #region Clientes
        public static string UDP_Listar_Clientes = "maqu.UDP_maqu_tbClientes_List";
        public static string UDP_Insertar_Clientes = "maqu.UDP_maqu_tbClientes_Insert";
        public static string UDP_Editar_Clientes = "maqu.UDP_maqu_tbClientes_Update";
        public static string UDP_Eliminar_Clientes = "maqu.UDP_maqu_tbClientes_Delete";
        #endregion

        #region Municipios
        public static string UDP_Listar_Municipios_DDL = "UDP_gral_tbMunicipios_ListDDL";
        #endregion

        #region Departamentos
        public static string UDP_Listar_Departamentos = "gral.UPD_gral_tbDepartamentos_List";
        #endregion

        #region EstadosCiviles
        public static string UDP_Listar_EstadosCiviles = "gral.UDP_gral_tbEstadosCiviles_List";
        #endregion
    }
}
