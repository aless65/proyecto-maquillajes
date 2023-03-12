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
            throw new NotImplementedException();
        }

        public int Insert(tbClientes item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();

            parametros.Add("@clie_Nombres", item.clie_Nombres, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_Apellidos", item.clie_Apellidos, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_Identidad", item.clie_Identidad, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_Sexo", item.clie_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_DireccionExacta", item.clie_DireccionExacta, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_Telefono", item.clie_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_CorreoElectronico", item.clie_CorreoElectronico, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_UsuCreacion", "1", DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_Clientes, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbClientes> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<tbClientes>(ScriptsDataBase.UDP_Listar_Clientes, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(tbClientes item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();

            parametros.Add("@clie_Nombres", item.clie_Nombres, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_Apellidos", item.clie_Apellidos, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_Identidad", item.clie_Identidad, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_Sexo", item.clie_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_DireccionExacta", item.clie_DireccionExacta, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_Telefono", item.clie_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_CorreoElectronico", item.clie_CorreoElectronico, DbType.String, ParameterDirection.Input);
            parametros.Add("@clie_UsuModificacion", "1", DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Editar_Clientes, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
