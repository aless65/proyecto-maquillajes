using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class MetodoPagoRepository : IRepository<tbMetodosPago>
    {
        public int Delete(tbMetodosPago item)
        {
            throw new NotImplementedException();
        }

        public int DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@meto_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Eliminar_MetodosPago, parametros, commandType: CommandType.StoredProcedure);
        }

        public tbMetodosPago find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbMetodosPago item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@meto_Nombre", item.meto_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@meto_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_MetodosPago, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbMetodosPago> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            return db.Query<tbMetodosPago>(ScriptsDataBase.UDP_Listar_MetodosPago, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbMetodosPago item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@meto_Id", item.meto_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@meto_Nombre", item.meto_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@meto_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Editar_MetodosPago, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
