using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class UsuarioRepository : IRepository<tbUsuarios>
    {
        public int Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios find(int? id)
        {
            throw new NotImplementedException();
        }
        public int Insert(tbUsuarios item)
        {
            //using var db = new AndreasContext();
            //db.tbCategorias.Add(item);
            //return item.cate_Id;
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parametros.Add("@user_Contrasena", item.user_Contrasena, DbType.String, ParameterDirection.Input);
            parametros.Add("@user_EsAdmin", item.user_EsAdmin, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@user_UsuCreacion",1, DbType.Int32, ParameterDirection.Input);
            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Insertar_Usuarios, parametros, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<tbUsuarios> List()
        {
            //using var db = new AndreasContext();
            //return db.tbCategorias.ToList();

            using var db = new SqlConnection(AndreasContext.ConnectionString);

            //var parametros = new DynamicParameters();
            //parametros.Add("@NoHaceNada", item.id, DbType.String, ParameterDirection.Input);
            //return db.Query<tbCategorias>(ScriptsDataBase.UDP_Listar_Categorias, parametros, commandType: CommandType.StoredProcedure);

            return db.Query<tbUsuarios>(ScriptsDataBase.UDP_Listar_Usuarios, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbUsuarios item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@user_Id", item.user_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@user_EsAdmin", item.user_EsAdmin, DbType.Boolean, ParameterDirection.Input);
            parametros.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@user_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_Usuarios, parametros, commandType: CommandType.StoredProcedure);
        }

        public int DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@user_Id",id, DbType.Int32, ParameterDirection.Input);
            
            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Eliminar_Usuarios, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
