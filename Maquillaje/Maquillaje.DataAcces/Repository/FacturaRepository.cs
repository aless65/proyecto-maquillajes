using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class FacturaRepository : IRepository<tbFacturas>
    {
        public int Delete(tbFacturas item)
        {
            throw new NotImplementedException();
        }

        public tbFacturas find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbFacturas item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();

            parametros.Add("@clie_Id", item.clie_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@meto_Id", item.meto_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@fact_usuCreacion", item.fact_UsuCreacion, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_Facturas, parametros, commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<tbFacturas> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbFacturas_List> ListView()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            return db.Query<VW_tbFacturas_List>(ScriptsDataBase.UDP_Listar_Facturas, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbFacturas item)
        {
            throw new NotImplementedException();
        }
    }
}
