using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace Maquillaje.DataAccess.Repository
{
    public class CategoriaRepository : IRepository<tbCategorias>
    {
        public int Delete(tbCategorias item)
        {
            throw new NotImplementedException();
        }

        public tbCategorias find(int? id)
        {
            using var db = new AndreasContext();
            var listado = db.tbCategorias.Find(id);
            return listado;
        }

        public int Insert(VW_maqu_tbCategorias_VW item)
        {
            //using var db = new AndreasContext();
            //db.tbCategorias.Add(item);
            //return item.cate_Id;
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@cate_Nombre", item.cate_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@cate_UsuCreacion", item.cate_UsuCreacion, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_Categorias, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_maqu_tbCategorias_VW> List()
        {
            //using var db = new AndreasContext();
            //return db.tbCategorias.ToList();

            using var db = new SqlConnection(AndreasContext.ConnectionString);

            //var parametros = new DynamicParameters();
            //parametros.Add("@NoHaceNada", item.id, DbType.String, ParameterDirection.Input);
            //return db.Query<tbCategorias>(ScriptsDataBase.UDP_Listar_Categorias, parametros, commandType: CommandType.StoredProcedure);

            return db.Query<VW_maqu_tbCategorias_VW>(ScriptsDataBase.UDP_Listar_Categorias, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_maqu_tbCategorias_VW> Details(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_maqu_tbCategorias_VW>(ScriptsDataBase.UDP_Listar_Categoria_View, null, commandType: CommandType.StoredProcedure);
        }


        public int Update(VW_maqu_tbCategorias_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@cate_Id", item.cate_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@cate_Nombre", item.cate_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@cate_UsuModificacion",item.cate_UsuModificacion, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_Categorias, parametros, commandType: CommandType.StoredProcedure);
        }

        public int DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();

            parametros.Add("@cate_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Eliminar_Categorias, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Insert(tbCategorias item)
        {
            throw new NotImplementedException();
        }

        public int Update(tbCategorias item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbCategorias> IRepository<tbCategorias>.List()
        {
            throw new NotImplementedException();
        }
    }
}
