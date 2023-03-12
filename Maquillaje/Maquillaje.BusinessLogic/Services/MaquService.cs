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
        private readonly ClienteRepository  _clienteRepository;
        private readonly MunicipioRepository _municipioRepository;
        private readonly DepartamentoRepository _departamentoRepository;

        public MaquService(CategoriaRepository categoriaRepository, EmpleadoRepository empleadoRepository, ClienteRepository clienteRepository,MunicipioRepository municipioRepository, DepartamentoRepository departamentoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _empleadoRepository = empleadoRepository;
            _clienteRepository = clienteRepository;
            _municipioRepository = municipioRepository;
            _departamentoRepository = departamentoRepository;
        }

        #region Categorias
        public IEnumerable<tbCategorias> ListadoCategorias(out string error)
        {
            error = string.Empty;
            try
            {
                return _categoriaRepository.List();
            }
            catch(Exception e)
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
        #endregion

        #region Departamentos

        #endregion

        #region Municipios
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
    }
}
