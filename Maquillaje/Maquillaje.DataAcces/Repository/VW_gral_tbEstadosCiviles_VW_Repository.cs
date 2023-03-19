using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class VW_gral_tbEstadosCiviles_VW_Repository : IRepository<VW_gral_tbEstadosCiviles_VW>
    {
        public int Delete(VW_gral_tbEstadosCiviles_VW item)
        {
            throw new NotImplementedException();
        }

        public VW_gral_tbEstadosCiviles_VW find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(VW_gral_tbEstadosCiviles_VW item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_gral_tbEstadosCiviles_VW> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_gral_tbEstadosCiviles_VW>(ScriptsDataBase.UDP_Listar_EstadosCivilesView, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(VW_gral_tbEstadosCiviles_VW item)
        {
            throw new NotImplementedException();
        }
    }
}
