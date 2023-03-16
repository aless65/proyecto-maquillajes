using System;
using System.Collections.Generic;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class ScriptsDataBase
    {
        #region Categorías
        public static string UDP_Listar_Categorias = "UDP_maqu_tbCategorias_List";
        public static string UDP_Editar_Categorias = "maqu.UDP_maqu_tbCategorias_UPDATE";
        public static string UDP_Insertar_Categorias = "UDP_maqu_tbCategorias_INSERT";
        public static string UDP_Eliminar_Categorias = "maqu.UDP_maqu_tbCategorias_Delete";
        public static string UDP_Listar_CategoriaById = "maqu.UDP_tbCategorias_maqu_ListById";
        #endregion

        #region Empleados
        public static string UDP_Listar_Empleado = "maqu.UDP_maqu_tbEmpleados_List";
        public static string UDP_Insertar_Empleado = "maqu.UPD_maqu_tbEmpleados_Insert";
        public static string UDP_Editar_Empleado = "maqu.UDP_maqu_tbEmpleados_Update";
        public static string UDP_Eliminar_Empleado = "maqu.UDP_maqu_tbEmpleados_Delete";
        public static string UDP_Editar_Empleado_Municipios_DDL = "maqu.UDP_tbEmpleados_maqu_GetMuni_Id";
        public static string UDP_Listar_Empleado_View = "maqu.UDP_maqu_tbEmpleados_View";
        #endregion

        #region Clientes
        public static string UDP_Listar_Clientes = "maqu.UDP_maqu_tbClientes_List";
        public static string UDP_Insertar_Clientes = "maqu.UDP_maqu_tbClientes_Insert";
        public static string UDP_Editar_Clientes = "maqu.UDP_maqu_tbClientes_Update";
        public static string UDP_Eliminar_Clientes = "maqu.UDP_maqu_tbClientes_Delete";
        public static string UDP_Editar_Clientes_Municipios_DDL = "maqu.UDP_tbClientes_maqu_GetMuni_Id";
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

        #region MetodosPago
        public static string UDP_Listar_MetodosPago = "maqu.UDP_maqu_tbMetodosPago";
        public static string UDP_Insertar_MetodosPago = "maqu.UDP_maqu_tbMetodosPago_INSERT";
        public static string UDP_Editar_MetodosPago = "maqu.UDP_maqu_tbMetodosPago_UPDATE";
        public static string UDP_Eliminar_MetodosPago = "maqu.UDP_maqu_tbMetodosPago_DELETE";
        #endregion

        #region Usuarios
        public static string UDP_Listar_Usuarios = "acce.UDP_acce_tbUsuarios_List";
        public static string UDP_Insertar_Usuarios = "acce.UDP_acce_tbUsuarios_Insert";
        #endregion

        #region Roles
        public static string UDP_Listar_Roles = "acce.UDP_acce_tbRoles_List";
        #endregion

        #region Facturas
        public static string UDP_Listar_Facturas = "maqu.UDP_maqu_tbFacturas_Listado";
        public static string UDP_Insertar_Facturas = "maqu.UDP_maqu_tbFacturas_Insert";
        #endregion

        #region Facturas detalles
        public static string UDP_Listar_FacturasDetalles = "maqu.VW_tbFacturasDetalles_List";
        public static string UDP_Insertar_FacturasDetalles = "maqu.UDP_maqu_tbFacturasDetalles_Insert";
        #endregion

        #region Productos
        public static string UDP_Listar_Productos_DDL = "maqu.UDP_maqu_tbProductos_ListDDL";
        public static string UDP_Precio_Producto = "maqu.UDP_maqu_tbProductos_Precios";
        #endregion
    }
}
