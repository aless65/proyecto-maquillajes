using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class EstadoCivilRepository : IRepository<tbEstadosCiviles>
    {
        public int Delete(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        public tbEstadosCiviles find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEstadosCiviles> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<tbEstadosCiviles>(ScriptsDataBase.UDP_Listar_Municipios_DDL, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }
    }
}
