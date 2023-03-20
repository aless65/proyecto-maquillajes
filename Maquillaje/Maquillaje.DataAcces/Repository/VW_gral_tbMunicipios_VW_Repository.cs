using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class VW_gral_tbMunicipios_VW_Repository : IRepository<VW_gral_tbMunicipios_VW>
    {
        public int Delete(VW_gral_tbMunicipios_VW item)
        {
            throw new NotImplementedException();
        }

        public VW_gral_tbMunicipios_VW find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(VW_gral_tbMunicipios_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@muni_Id", item.muni_id, DbType.String, ParameterDirection.Input);
            parametros.Add("@muni_Nombre", item.muni_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@depa_Id", item.depa_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@muni_UsuCreacion", item.muni_UsuCreacion, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Insertar_Municipios, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_gral_tbMunicipios_VW> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_gral_tbMunicipios_VW>(ScriptsDataBase.UDP_Listar_Municipios, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(VW_gral_tbMunicipios_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@muni_Id", item.muni_id, DbType.String, ParameterDirection.Input);
            parametros.Add("@muni_Nombre", item.muni_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@depa_Id", item.depa_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@muni_UsuModificacion", item.muni_UsuModificacion, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_Municipios, parametros, commandType: CommandType.StoredProcedure);
        }

        public int DeleteConfirmed(string id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@muni_Id", id, DbType.String, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Elimnar_Municipios, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
