using System;
using Maquillaje.Entities.Entities;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace Maquillaje.DataAccess.Repository
{
    public class VW_acce_tbUsuarios_View_Repository : IRepository<VW_acce_tbUsuarios_View>
    {
        public int Delete(VW_acce_tbUsuarios_View item)
        {
            throw new NotImplementedException();
        }

        public VW_acce_tbUsuarios_View find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_acce_tbUsuarios_View> Details(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@user_Id", id, DbType.Int32, ParameterDirection.Input);
            return db.Query<VW_acce_tbUsuarios_View>(ScriptsDataBase.UDP_View_Usuarios, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Insert(VW_acce_tbUsuarios_View item)
        {
            throw new NotImplementedException();
        }
        public int Recover(string usuario,string contrasena)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@user_NombreUsuario", usuario, DbType.String, ParameterDirection.Input);
            parametros.Add("@user_Contrasena", contrasena, DbType.String, ParameterDirection.Input);
            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Recover, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_acce_tbUsuarios_View> List()
        {
            throw new NotImplementedException();
        }

        public int Update(VW_acce_tbUsuarios_View item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_acce_tbUsuarios_View> Login(string usuario, string contrasena)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@user_NombreUsuario", usuario, DbType.String, ParameterDirection.Input);
            parametros.Add("@user_Contrasena", contrasena, DbType.String, ParameterDirection.Input);
            return db.Query<VW_acce_tbUsuarios_View>(ScriptsDataBase.UDP_Login, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
