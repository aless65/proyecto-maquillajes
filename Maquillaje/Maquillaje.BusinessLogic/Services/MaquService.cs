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

        public MaquService(CategoriaRepository categoriaRepository, EmpleadoRepository empleadoRepository, ClienteRepository clienteRepository, MunicipioRepository municipioRepository, DepartamentoRepository departamentoRepository, EstadoCivilRepository estadoCivilRepository)
        {
            _categoriaRepository = categoriaRepository;
            _empleadoRepository = empleadoRepository;
            _clienteRepository = clienteRepository;
            _municipioRepository = municipioRepository;
            _departamentoRepository = departamentoRepository;
            _estadoCivilRepository = estadoCivilRepository;
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

        public IEnumerable<tbEmpleados> UpdateEmpleadosMuniDDL(int id)
        {
            return _empleadoRepository.MunicipiosPorEmpleado(id);
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
                return _clienteRepository.find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateClientes(tbClientes cliente)
        {
            try
            {
                var clienteExistente = _clienteRepository.find(cliente.clie_Id);

                if (clienteExistente == null)
                {
                    return false;
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

                    _clienteRepository.Update(clienteExistente);

                    return true;
                }
            }
            catch
            {
                return false;
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
    }
}
