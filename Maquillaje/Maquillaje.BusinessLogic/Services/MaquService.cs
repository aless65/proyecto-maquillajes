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
        private readonly MunicipioRepository _municipioRepository;
        private readonly DepartamentoRepository _departamentoRepository;
        private readonly EstadoCivilRepository _estadoCivilRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly RolRepository _rolRepository;

        public MaquService(CategoriaRepository categoriaRepository, EmpleadoRepository empleadoRepository, ClienteRepository clienteRepository, MunicipioRepository municipioRepository, DepartamentoRepository departamentoRepository, EstadoCivilRepository estadoCivilRepository, UsuarioRepository usuarioRepository, RolRepository rolRepository)
        {
            _categoriaRepository = categoriaRepository;
            _empleadoRepository = empleadoRepository;
            _clienteRepository = clienteRepository;
            _municipioRepository = municipioRepository;
            _departamentoRepository = departamentoRepository;
            _estadoCivilRepository = estadoCivilRepository;
            _usuarioRepository = usuarioRepository;
            _rolRepository = rolRepository;
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
            catch (Exception error)
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

        public bool UpdateEmpelado(tbEmpleados empleado)
        {
            try
            {
                var empleadoExistente = _empleadoRepository.find(empleado.empe_Id);

                if (empleadoExistente == null)
                {
                    return false;
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

                    _empleadoRepository.Update(empleadoExistente);

                    return true;
                }
            }
            catch(Exception error)
            {
                return false;
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

        #region Departamentos
        public IEnumerable<tbDepartamentos> ListadoDepartamento(out string error)
        {
            error = string.Empty;
            try
            {
                return _departamentoRepository.List();
            }
            catch (Exception e)
            {
                error = e.Message;
                return Enumerable.Empty<tbDepartamentos>();
            }
        }
        #endregion

        #region Municipios
        public IEnumerable<tbMunicipios> GetMunicipiosPorDepartamento(string departamentoId)
        {
            //var municipios = _context.Municipios.Where(m => m.DepartamentoId == departamentoId);
            var municipios = _municipioRepository.CargarMunicipios(departamentoId); 
            return (municipios);
        }
        #endregion

        #region EstadosCiviles
        public IEnumerable<tbEstadosCiviles> ListadoEstadosCiviles(out string error)
        {
            error = string.Empty;
            try
            {
                return _estadoCivilRepository.List();
            }
            catch (Exception e)
            {
                error = e.Message;
                return Enumerable.Empty<tbEstadosCiviles>();
            }
        }
        #endregion

        #region Usuario
        public IEnumerable<tbUsuarios> ListadoUsuarios(out string error)
        {
            error = string.Empty;
            try
            {
                return _usuarioRepository.List();
            }
            catch (Exception e)
            {
                error = e.Message;
                return Enumerable.Empty<tbUsuarios>();
            }
        }

        public int InsertUsuario(tbUsuarios tbUsuarios)
        {
            return _usuarioRepository.Insert(tbUsuarios);
        }

        #endregion

        #region Roles
        public IEnumerable<tbRoles> ListadoRoles(out string error)
        {
            error = string.Empty;
            try
            {
                return _rolRepository.List();
            }
            catch (Exception e)
            {
                error = e.Message;
                return Enumerable.Empty<tbRoles>();
            }
        }
        #endregion
    }
}
