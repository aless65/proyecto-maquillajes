using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class VW_gral_tbDepartamentos_VW_Repository : IRepository<VW_gral_tbDepartamentos_VW>
    {
        public int Delete(VW_gral_tbDepartamentos_VW item)
        {
            throw new NotImplementedException();
        }

        public int DeleteConfirmed(string id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@depa_Id",id, DbType.String, ParameterDirection.Input);
            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Eliminar_Departamentos, parametros, commandType: CommandType.StoredProcedure);
        }

        public VW_gral_tbDepartamentos_VW find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(VW_gral_tbDepartamentos_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@depa_Id", item.depa_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@depa_Nombre", item.depa_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@depa_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);


            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Insertar_Departamentos, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_gral_tbDepartamentos_VW> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_gral_tbDepartamentos_VW>(ScriptsDataBase.UDP_Listar_Departamentos_Vista, null, commandType: CommandType.StoredProcedure);

        }

        public int Update(VW_gral_tbDepartamentos_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@depa_Id", item.depa_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@depa_Nombre", item.depa_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@depa_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);
     

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_Departamentos, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
