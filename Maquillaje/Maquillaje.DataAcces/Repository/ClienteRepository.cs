using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace Maquillaje.DataAccess.Repository
{
    public class ClienteRepository : IRepository<tbClientes>
    {
        public int Delete(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public tbClientes find(int? id)
        {
            using var db = new AndreasContext();
            var listado = db.tbClientes.Find(id);
            return listado;
        }

        public int Insert(tbClientes item)
        {
            //using var db = new SqlConnection(AndreasContext.ConnectionString);
            //var parametros = new DynamicParameters();
            //parametros.Add("@empe_Nombres", item.empe_Nombres, DbType.String, ParameterDirection.Input);
            //parametros.Add("@empe_Apellidos", item.empe_Apellidos, DbType.String, ParameterDirection.Input);
            //parametros.Add("@empe_Identidad", item.empe_Identidad, DbType.String, ParameterDirection.Input);
            //parametros.Add("@empe_FechaNacimiento", item.empe_FechaNacimiento, DbType.String, ParameterDirection.Input);
            //parametros.Add("@empe_Sexo", item.empe_Sexo, DbType.String, ParameterDirection.Input);
            //parametros.Add("@estacivi_Id", item.estacivi_Id, DbType.Int32, ParameterDirection.Input);
            //parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            //parametros.Add("@empe_Direccion", item.empe_Direccion, DbType.String, ParameterDirection.Input);
            //parametros.Add("@empe_Telefono", item.empe_Telefono, DbType.String, ParameterDirection.Input);
            //parametros.Add("@empe_CorreoElectronico", item.empe_CorreoElectronico, DbType.String, ParameterDirection.Input);
            //parametros.Add("@empe_UsuCreacion", item.empe_UsuCreacion, DbType.String, ParameterDirection.Input);

            //return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_Empleado, parametros, commandType: CommandType.StoredProcedure);;1

            return 1;
        }

        public IEnumerable<tbClientes> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<tbClientes>(ScriptsDataBase.UDP_Listar_Clientes, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbClientes item)
        {
            throw new NotImplementedException();
        }
    }
}
