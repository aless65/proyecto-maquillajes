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

        public AcceService(UsuarioRepository usuarioRepository, RolRepository rolRepository)
        {
            _usuarioRepository = usuarioRepository;
            _rolRepository = rolRepository;
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
