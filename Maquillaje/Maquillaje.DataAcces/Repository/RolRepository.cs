using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class RolRepository : IRepository<tbRoles>
    {
        public int Delete(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public tbRoles find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbRoles> List()
        {
             using var db = new SqlConnection(AndreasContext.ConnectionString);
             return db.Query<tbRoles>(ScriptsDataBase.UDP_Listar_Roles, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbRoles item)
        {
            throw new NotImplementedException();
        }
    }
}
