using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class VW_maqu_tbProductos_VW_Repository : IRepository<VW_maqu_tbProductos_VW>
    {
        public int Delete(VW_maqu_tbProductos_VW item)
        {
            throw new NotImplementedException();
        }
        public int DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            var parametros = new DynamicParameters();

            parametros.Add("@prod_Id", id, DbType.String, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Eliminar_Producto, parametros, commandType: CommandType.StoredProcedure);
            
        }

        public VW_maqu_tbProductos_VW find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(VW_maqu_tbProductos_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@prod_Nombre", item.prod_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@prod_PrecioUni", item.prod_PrecioUni, DbType.Decimal, ParameterDirection.Input);
            parametros.Add("@cate_Id", item.cate_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prov_Id", item.prov_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prod_Stock", item.prod_Stock, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prod_UsuCreacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Insertar_Productos, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_maqu_tbProductos_VW> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_maqu_tbProductos_VW>(ScriptsDataBase.UDP_Listar_Productos, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(VW_maqu_tbProductos_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@prod_Id", item.prod_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prod_Nombre", item.prod_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@prod_PrecioUni", item.prod_PrecioUni, DbType.Decimal, ParameterDirection.Input);
            parametros.Add("@cate_Id", item.cate_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prov_Id", item.prov_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prod_Stock", item.prod_Stock, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prod_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_Producto, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
