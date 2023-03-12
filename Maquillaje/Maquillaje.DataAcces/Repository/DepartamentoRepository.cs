using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class DepartamentoRepository : IRepository<tbDepartamentos>
    {
        public int Delete(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }

        public tbDepartamentos find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbDepartamentos> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<tbDepartamentos>(ScriptsDataBase.UDP_Listar_Departamentos, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }
    }
}
