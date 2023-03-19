using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class VW_gral_tbEstadosCiviles_VW_Repository : IRepository<VW_gral_tbEstadosCiviles_VW>
    {
        public int Delete(VW_gral_tbEstadosCiviles_VW item)
        {
            throw new NotImplementedException();
        }
        public int DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@estacivi_Id", id, DbType.String, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Eliminar_EstadosCiviles, parametros, commandType: CommandType.StoredProcedure);
        }


        public VW_gral_tbEstadosCiviles_VW find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(VW_gral_tbEstadosCiviles_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@estacivi_Nombre", item.estacivi_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@estacivi_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);


            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Insertar_EstadosCiviles, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_gral_tbEstadosCiviles_VW> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_gral_tbEstadosCiviles_VW>(ScriptsDataBase.UDP_Listar_EstadosCivilesView, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(VW_gral_tbEstadosCiviles_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@estacivi_Id", item.estacivi_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@estacivi_Nombre", item.estacivi_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@estacivi_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_EstadosCiviles, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
