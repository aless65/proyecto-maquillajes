﻿using System;
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
        public static string UDP_Listar_Empleado = "UDP_maqu_tbEmpleados_List";
        public static string UDP_Insertar_Empleado = "UPD_maqu_tbEmpleados_Insert";
        #endregion

        #region Clientes
        public static string UDP_Listar_Clientes = "maqu.UDP_maqu_tbClientes_List";
        public static string UDP_Insertar_Clientes = "maqu.UDP_maqu_tbClientes_Insert";
        #endregion

        #region Municipios
        public static string UDP_Listar_Municipios_DDL = "UDP_gral_tbMunicipios_ListDDL";
        #endregion
    }
}
