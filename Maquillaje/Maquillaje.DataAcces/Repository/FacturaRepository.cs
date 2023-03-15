using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class FacturaRepository : IRepository<tbFacturas>
    {
        public int Delete(tbFacturas item)
        {
            throw new NotImplementedException();
        }

        public tbFacturas find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbFacturas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbFacturas> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbFacturas_List> ListView()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            return db.Query<VW_tbFacturas_List>(ScriptsDataBase.UDP_Listar_Facturas, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbFacturas item)
        {
            throw new NotImplementedException();
        }
    }
}
