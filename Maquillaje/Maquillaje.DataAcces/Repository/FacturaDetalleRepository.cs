using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class FacturaDetalleRepository : IRepository<tbFacturasDetalles>
    {
        public int Delete(tbFacturasDetalles item)
        {
            throw new NotImplementedException();
        }

        public int DeleteConfirmed(int id)
        {
            var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@factdeta_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Eliminar_FacturasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }

        public tbFacturasDetalles find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbFacturasDetalles item)
        {
            var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@fact_Id", item.fact_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prod_Id", item.prod_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@factdeta_Cantidad", item.factdeta_Cantidad, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@factdeta_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_FacturasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<tbFacturasDetalles> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbFacturasDetalles_List> ListView(int id)
        {
            var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@fact_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.Query<VW_tbFacturasDetalles_List>(ScriptsDataBase.UDP_Listar_FacturasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbFacturasDetalles item)
        {
            var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@factdeta_Id", item.factdeta_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prod_Id", item.prod_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@factdeta_Cantidad", item.factdeta_Cantidad, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@factdeta_UsuModificacion", item.factdeta_UsuModificacion, DbType.Decimal, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Editar_FacturasDetalles, parametros, commandType: CommandType.StoredProcedure);
        }

        public int RevisarStock(int id, int cantidad)
        {
            var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@prod_Stock", cantidad, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prod_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_RevisarStock, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
