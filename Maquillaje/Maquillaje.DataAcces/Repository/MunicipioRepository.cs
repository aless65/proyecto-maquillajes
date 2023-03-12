using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class MunicipioRepository : IRepository<tbMunicipios>
    {
        public int Delete(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public tbMunicipios find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMunicipios> List()
        {
            throw new NotImplementedException();
        }

        public int Update(tbMunicipios item)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<tbMunicipios> List(string id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@depa_Id", id, DbType.String, ParameterDirection.Input);


            return db.Query<tbMunicipios>(ScriptsDataBase.UDP_Listar_Municipios_DDL, parametros, commandType: CommandType.StoredProcedure);
        }

    }
}
