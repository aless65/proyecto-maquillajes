using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class EmpleadoRepository : IRepository<tbEmpleados>
    {
        public int Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados find(int? id)
        {
            using var db = new AndreasContext();
            var listado = db.tbEmpleados.Find(id);
            return listado;
        }

        public int Insert(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEmpleados> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<tbEmpleados>(ScriptsDataBase.UDP_Listar_Empleado, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbEmpleados item)
        {
            throw new NotImplementedException();
        }
    }
}
