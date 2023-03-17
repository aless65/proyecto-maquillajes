﻿using Maquillaje.DataAccess.Repository;
using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.BusinessLogic.Services
{
    public class GralService
    {
        private readonly MunicipioRepository _municipioRepository;
        private readonly DepartamentoRepository _departamentoRepository;
        private readonly EstadoCivilRepository _estadoCivilRepository;
        private readonly VW_gral_tbDepartamentos_VW_Repository _vw_gral_tbDepartamentos_vw_Repository;    

        public GralService(MunicipioRepository municipioRepository, DepartamentoRepository departamentoRepository, 
            EstadoCivilRepository estadoCivilRepository,VW_gral_tbDepartamentos_VW_Repository vW_Gral_TbDepartamentos_VW_Repository)
        {
            _municipioRepository = municipioRepository;
            _departamentoRepository = departamentoRepository;
            _estadoCivilRepository = estadoCivilRepository;
            _vw_gral_tbDepartamentos_vw_Repository = vW_Gral_TbDepartamentos_VW_Repository;
        }

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

        public IEnumerable<VW_gral_tbDepartamentos_VW> ListadoDepartamentosView(out string error)
        {
            error = string.Empty;
            try
            {
                return _vw_gral_tbDepartamentos_vw_Repository.List();
            }
            catch (Exception e)
            {
                error = e.Message;
                return Enumerable.Empty<VW_gral_tbDepartamentos_VW>();
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
