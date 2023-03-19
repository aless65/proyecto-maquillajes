using Maquillaje.DataAccess.Repository;
using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.BusinessLogic.Services
{
    public class MaquService
    {
        private readonly CategoriaRepository _categoriaRepository;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly MetodoPagoRepository _metodoPagoRepository;
        private readonly FacturaRepository _facturaRepository;
        private readonly FacturaDetalleRepository _facturaDetalleRepository;
        private readonly ProductoRepository _productoRepository;
        private readonly VW_maqu_tbProductos_VW_Repository _vw_maqu_tbProductos_VW_Repository;
        private readonly VW_maqu_tbProveedores_VW_Repository _vw_maqu_tbProveedores_VW_Repository;
        private readonly VW_maqu_tbSucursales_VW_Repository _VW_maqu_tbSucursales_VW_Repository;
        public MaquService(CategoriaRepository categoriaRepository, EmpleadoRepository empleadoRepository, ClienteRepository clienteRepository, MetodoPagoRepository metodoPagoRepository,
                           FacturaRepository facturaRepository, FacturaDetalleRepository facturaDetalleRepository, ProductoRepository productoRepository,
                           VW_maqu_tbProductos_VW_Repository vw_maqu_tbProductos_VW_Repository, VW_maqu_tbProveedores_VW_Repository vw_maqu_tbProveedores_VW_Repository,
                           VW_maqu_tbSucursales_VW_Repository vW_Maqu_TbSucursales_VW_Repository)
        {
            _categoriaRepository = categoriaRepository;
            _empleadoRepository = empleadoRepository;
            _clienteRepository = clienteRepository;
            _metodoPagoRepository = metodoPagoRepository;
            _facturaRepository = facturaRepository;
            _facturaDetalleRepository = facturaDetalleRepository;
            _productoRepository = productoRepository;
            _vw_maqu_tbProductos_VW_Repository = vw_maqu_tbProductos_VW_Repository;
            _vw_maqu_tbProveedores_VW_Repository = vw_maqu_tbProveedores_VW_Repository;
            _VW_maqu_tbSucursales_VW_Repository = vW_Maqu_TbSucursales_VW_Repository;
        }

        #region Categorias
        public IEnumerable<tbCategorias> ListadoCategorias(out string error)
        {
            error = string.Empty;
            try
            {
                return _categoriaRepository.List();
            }
            catch (Exception e)
            {
                error = e.Message;
                return Enumerable.Empty<tbCategorias>();
            }
        }

        public int InsertCategorias(tbCategorias tbCategorias)
        {
            return _categoriaRepository.Insert(tbCategorias);
        }

        public int EditCategorias(tbCategorias categoria)
        {

            try
            {
                var resultado = _categoriaRepository.Update(categoria);

                return resultado;
            }
            catch 
            {
                return 0;
            }

        }

        public int DeleteCategoria(int id)
        {
            try
            {
                return _categoriaRepository.DeleteConfirmed(id);
            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<tbCategorias> CategoriaDetails(int id,out string error)
        {
            error = string.Empty;

            try
            {
                return _categoriaRepository.Details(id);
            }
            catch (Exception e)
            {

                error = e.Message;
                return Enumerable.Empty<tbCategorias>();
            }
        }
        #endregion

        #region Empleado

        public IEnumerable<tbEmpleados> ListadoEmpleados(out string error)
        {
            error = string.Empty;

            try
            {
                return _empleadoRepository.List();
            }
            catch (Exception e)
            {

                error = e.Message;
                return Enumerable.Empty<tbEmpleados>();
            }
        }

        public IEnumerable<VW_maqu_tbEmpleados_View> ListadoEmpleadosView(out string error)
        {
            error = string.Empty;

            try
            {
                return _empleadoRepository.View();
            }
            catch (Exception e)
            {

                error = e.Message;
                return Enumerable.Empty<VW_maqu_tbEmpleados_View>();
            }
        }

        public int InsertEmpleado(tbEmpleados tbEmpleados)
        {
            try
            {
                return _empleadoRepository.Insert(tbEmpleados);
            }
            catch
            {
                return 0;
            }
        }

        public tbEmpleados ObtenerIDEmpleado(int id)
        {
            try
            {
                return _empleadoRepository.find(id);
            }
            catch
            {
                return null;
            }
        }

        public int UpdateEmpelado(tbEmpleados empleado)
        {
            try
            {
                var empleadoExistente = _empleadoRepository.find(empleado.empe_Id);

                if (empleadoExistente == null)
                {
                    return 0;
                }
                else
                {
                    empleadoExistente.empe_Nombres = empleado.empe_Nombres;
                    empleadoExistente.empe_Apellidos = empleado.empe_Apellidos;
                    empleadoExistente.empe_Identidad = empleado.empe_Identidad;
                    empleadoExistente.empe_Sexo = empleado.empe_Sexo;
                    empleadoExistente.muni_Id = empleado.muni_Id;
                    empleadoExistente.empe_FechaNacimiento = empleado.empe_FechaNacimiento;
                    empleadoExistente.empe_Telefono = empleado.empe_Telefono;
                    empleadoExistente.empe_CorreoElectronico = empleado.empe_CorreoElectronico;
                    empleadoExistente.estacivi_Id = empleado.estacivi_Id;
                    empleadoExistente.empe_Direccion = empleado.empe_Direccion;

                    return _empleadoRepository.Update(empleadoExistente); ;
                }
            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<VW_maqu_tbEmpleados_DDLMunicipios> UpdateEmpleadosMuniDDL(int id)
        {
            return _empleadoRepository.GetMuni_IdByEmpe_Id(id);
        }

        public int DeleteEmpleado(int id)
        {
            return _empleadoRepository.DeleteConfirmed(id);
        }

        #endregion

        #region Clientes
        public IEnumerable<tbClientes> ListadoClientes(out string error)
        {
            error = string.Empty;

            try
            {
                return _clienteRepository.List();
            }
            catch (Exception e)
            {
                error = e.Message;
                return Enumerable.Empty<tbClientes>();
            }
        }

        public IEnumerable<VW_maqu_tbClientes_VW> DetailsClientes(out string error)
        {
            error = string.Empty;

            try
            {
                return _clienteRepository.Details();
            }
            catch (Exception e)
            {
                error = e.Message;
                return Enumerable.Empty<VW_maqu_tbClientes_VW>();
            }
        }

        public int InsertClientes(tbClientes tbClientes)
        {
            return _clienteRepository.Insert(tbClientes);
        }

        public tbClientes ObtenerIDCliente(int id)
        {
            try
            {
                var probar = _clienteRepository.find(id);
                return _clienteRepository.find(id);
            }
            catch
            {
                return null;
            }
        }

        public int UpdateClientes(tbClientes cliente)
        {
            try
            {
                var clienteExistente = _clienteRepository.find(cliente.clie_Id);

                if (clienteExistente == null)
                {
                    return 0;
                }
                else
                {
                    clienteExistente.clie_Nombres = cliente.clie_Nombres;
                    clienteExistente.clie_Apellidos = cliente.clie_Apellidos;
                    clienteExistente.clie_Identidad = cliente.clie_Identidad;
                    clienteExistente.clie_Sexo = cliente.clie_Sexo;
                    clienteExistente.muni_Id = cliente.muni_Id;
                    clienteExistente.clie_DireccionExacta = cliente.clie_DireccionExacta;
                    clienteExistente.clie_Telefono = cliente.clie_Telefono;
                    clienteExistente.clie_CorreoElectronico = cliente.clie_CorreoElectronico;

                    return _clienteRepository.Update(clienteExistente);
                }
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteCliente(int id)
        {
            try
            {
                return _clienteRepository.DeleteConfirmed(id);
            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<VW_maqu_tbClientes_DDLMunicipios> UpdateClientesMuniDDL(int id)
        {
            return _clienteRepository.GetMuni_IdByClie_Id(id);
        }
        #endregion

        #region Métodos pago
        public IEnumerable<tbMetodosPago> ListadoMetodosPago()
        {
            try
            {
                return _metodoPagoRepository.List();
            }
            catch
            {
                return Enumerable.Empty<tbMetodosPago>();
            }
        }

        public IEnumerable<VW_maqu_tbMetodosPago_View> MetodosPagoDetails()
        {
            try
            {
                return _metodoPagoRepository.Details();
            }
            catch
            {
                return Enumerable.Empty<VW_maqu_tbMetodosPago_View>();
            }
        }

        public int InsertMetodosPago(tbMetodosPago item)
        {
            return _metodoPagoRepository.Insert(item);
        }

        public int UpdateMetodosPago(tbMetodosPago item)
        {
            return _metodoPagoRepository.Update(item);
        }

        public int DeleteMetodosPago(int id)
        {
            return _metodoPagoRepository.DeleteConfirmed(id);
        }
        #endregion

        #region Facturas
        public IEnumerable<VW_tbFacturas_List> ListadoFacturas()
        {
            try
            {
                return _facturaRepository.ListView();
            }
            catch
            {
                return Enumerable.Empty<VW_tbFacturas_List>();
            }
        }

        public int InsertFacturas(tbFacturas item)
        {
            return _facturaRepository.Insert(item);
        }
        #endregion

        #region Facturas Detalles
        public IEnumerable<VW_tbFacturasDetalles_List> ListadoFacturasDetalles(int id)
        {
            try
            {
                return _facturaDetalleRepository.ListView(id);
            }
            catch
            {
                return Enumerable.Empty<VW_tbFacturasDetalles_List>();
            }
        }

        public int InsertFacturasDetalles(tbFacturasDetalles item)
        {
            return _facturaDetalleRepository.Insert(item);
        }

        public int DeleteFacturasDetalles(int id)
        {
            return _facturaDetalleRepository.DeleteConfirmed(id);
        }

        public int UpdateFacturasDetalles(tbFacturasDetalles item)
        {
            return _facturaDetalleRepository.Update(item);
        }
        #endregion

        #region Producto
        public IEnumerable<tbProductos> ListadoProductos(int id)
        {
            try
            {
                return _productoRepository.ListDDL(id);
            }
            catch
            {
                return Enumerable.Empty<tbProductos>();
            }
        }

        public IEnumerable<VW_maqu_tbProductos_VW> ListadoProductosView()
        {
            try
            {
                return _vw_maqu_tbProductos_VW_Repository.List();
            }
            catch
            {
                return Enumerable.Empty<VW_maqu_tbProductos_VW>();
            }
        }

        public int InsertProducto(VW_maqu_tbProductos_VW item)
        {
            try
            {
                return _vw_maqu_tbProductos_VW_Repository.Insert(item);
            }
            catch(Exception error)
            {
                return 0;
            }
  
        }

        public int EditProducto(VW_maqu_tbProductos_VW item)
        {

            try
            {
                var resultado = _vw_maqu_tbProductos_VW_Repository.Update(item);

                return resultado;
            }
            catch
            {
                return 0;
            }

        }

        public int DeleteProducto(int id)
        {

            try
            {
                var resultado = _vw_maqu_tbProductos_VW_Repository.DeleteConfirmed(id);

                return resultado;
            }
            catch
            {
                return 0;
            }

        }

        public IEnumerable<tbProductos> PrecioProducto(int id)
        {
            return _productoRepository.PrecioProducto(id);
        }
        #endregion

        #region Proveedores
        public IEnumerable<VW_maqu_tbProveedores_VW> ListadoProveedores()
        {
            try
            {
                return _vw_maqu_tbProveedores_VW_Repository.List();
            }
            catch
            {
                return Enumerable.Empty<VW_maqu_tbProveedores_VW>();
            }
        }

        public int InsertarProveedor(VW_maqu_tbProveedores_VW item)
        {
            try
            {
                return _vw_maqu_tbProveedores_VW_Repository.Insert(item);
            }
            catch(Exception error)
            {
                return 0;
            }
          
        }

        public int DeleteProveedor(int id)
        {
            try
            {
                return _vw_maqu_tbProveedores_VW_Repository.DeleteConfirmed(id);
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        public int EditarProveedor(VW_maqu_tbProveedores_VW item)
        {
            try
            {
                var resultado = _vw_maqu_tbProveedores_VW_Repository.Update(item);
                return resultado;
            }
            catch
            {
                return 0;
            }

        }
        #endregion

        #region Sucursal
        public IEnumerable<VW_maqu_tbSucursales_VW> ListadoSucursales()
        {
            try
            {
                return _VW_maqu_tbSucursales_VW_Repository.List();
            }
            catch
            {
                return Enumerable.Empty<VW_maqu_tbSucursales_VW>();
            }
        }

        public int InsertarSucursal(VW_maqu_tbSucursales_VW item)
        {
            try
            {
                return _VW_maqu_tbSucursales_VW_Repository.Insert(item);
            }
            catch (Exception error)
            {
                return 0;
            }
        }


        public int EditarSucursal(VW_maqu_tbSucursales_VW item)
        {
            try
            {
                return _VW_maqu_tbSucursales_VW_Repository.Update(item);
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        public int EliminarSucursal(int id)
        {
            try
            {
                return _VW_maqu_tbSucursales_VW_Repository.DeleteConfirmed(id);
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        #endregion
    }
}
