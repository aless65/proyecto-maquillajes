using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class ProductoRepository : IRepository<tbProductos>
    {
        public int Delete(tbProductos item)
        {
            throw new NotImplementedException();
        }

        public tbProductos find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbProductos item)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbProductos> List()
        {
            throw new NotImplementedException();
        } 

        public IEnumerable<tbProductos> ListDDL(int id)
        {
            var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@cate_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.Query<tbProductos>(ScriptsDataBase.UDP_Listar_Productos_DDL, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbProductos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbProductos> PrecioProducto(int id)
        {
            var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@prod_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.Query<tbProductos>(ScriptsDataBase.UDP_Precio_Producto, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
