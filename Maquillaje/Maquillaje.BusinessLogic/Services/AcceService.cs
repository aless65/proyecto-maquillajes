using Maquillaje.DataAccess.Repository;
using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maquillaje.BusinessLogic.Services
{
    public class AcceService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly RolRepository _rolRepository;
        private readonly VW_acce_tbUsuarios_View_Repository _VW_acce_tbUsuarios_View_Repository;

        public AcceService(UsuarioRepository usuarioRepository, RolRepository rolRepository,VW_acce_tbUsuarios_View_Repository VW_acce_tbUsuarios_View_Repository)
        {
            _usuarioRepository = usuarioRepository;
            _rolRepository = rolRepository;
            _VW_acce_tbUsuarios_View_Repository = VW_acce_tbUsuarios_View_Repository;
        }

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

        public IEnumerable<VW_acce_tbUsuarios_View> Login(string usuario, string contrasena)
        {
  
            try
            {
                return _VW_acce_tbUsuarios_View_Repository.Login(usuario,contrasena);
            }
            catch (Exception e)
            {    
                return Enumerable.Empty<VW_acce_tbUsuarios_View>();
            }
        }

        public int InsertUsuario(tbUsuarios tbUsuarios)
        {
            return _usuarioRepository.Insert(tbUsuarios);
        }

        public int EditUsuario(tbUsuarios usuarios)
        {
            try
            {
                var resultado = _usuarioRepository.Update(usuarios);

                return resultado;
            }
            catch (Exception error)
            {
                return 0;
            }

        }

        public IEnumerable<VW_acce_tbUsuarios_View> Details(int id)
        {
            var resultado = _VW_acce_tbUsuarios_View_Repository.Details(id);
            return resultado;
        }

        public int DeleteUsuario(int id)
        {
            try
            {
                return _usuarioRepository.DeleteConfirmed(id);
            }
            catch
            {
                return 0;
            }
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
