using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class UsuarioRepository : IRepository<tbUsuarios>
    {
        public int Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbUsuarios> List()
        {
            //using var db = new AndreasContext();
            //return db.tbCategorias.ToList();

            using var db = new SqlConnection(AndreasContext.ConnectionString);

            //var parametros = new DynamicParameters();
            //parametros.Add("@NoHaceNada", item.id, DbType.String, ParameterDirection.Input);
            //return db.Query<tbCategorias>(ScriptsDataBase.UDP_Listar_Categorias, parametros, commandType: CommandType.StoredProcedure);

            return db.Query<tbUsuarios>(ScriptsDataBase.UDP_Listar_Categorias, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbUsuarios item)
        {
            throw new NotImplementedException();
        }
    }
}
