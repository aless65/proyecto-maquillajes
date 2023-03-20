using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class VW_maqu_tbSucursales_VW_Repository : IRepository<VW_maqu_tbSucursales_VW>
    {
        public int Delete(VW_maqu_tbSucursales_VW item)
        {
            throw new NotImplementedException();
        }

        public VW_maqu_tbSucursales_VW find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(VW_maqu_tbSucursales_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@sucu_Descripcion", item.sucu_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@sucu_DireccionExacta", item.sucu_DireccionExacta, DbType.String, ParameterDirection.Input);
            parametros.Add("@sucu_UsuCreacion", item.sucu_UsuCreacion, DbType.String, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Insertar_Sucursales, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_maqu_tbSucursales_VW> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_maqu_tbSucursales_VW>(ScriptsDataBase.UDP_Listar_Sucursales, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(VW_maqu_tbSucursales_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@sucu_Id", item.sucu_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@sucu_Descripcion", item.sucu_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@sucu_DireccionExacta", item.sucu_DireccionExacta, DbType.String, ParameterDirection.Input);
            parametros.Add("@sucu_UsuModificacion", item.sucu_UsuModificacion, DbType.String, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_Sucursales, parametros, commandType: CommandType.StoredProcedure);
        }

        public int DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@sucu_Id", id, DbType.String, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Elimnar_Sucursales, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
