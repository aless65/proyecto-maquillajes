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

        public VW_maqu_tbProductos_VW find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(VW_maqu_tbProductos_VW item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_maqu_tbProductos_VW> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_maqu_tbProductos_VW>(ScriptsDataBase.UDP_Listar_Productos, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(VW_maqu_tbProductos_VW item)
        {
            throw new NotImplementedException();
        }
    }
}
