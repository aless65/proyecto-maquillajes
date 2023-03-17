using Dapper;
using Maquillaje.Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public class VW_maqu_tbProveedores_VW_Repository : IRepository<VW_maqu_tbProveedores_VW>
    {
        public int Delete(VW_maqu_tbProveedores_VW item)
        {
            throw new NotImplementedException();
        }

        public VW_maqu_tbProveedores_VW find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(VW_maqu_tbProveedores_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@prov_Nombre", item.prov_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@prov_CorreoElectronico", item.prov_CorreoElectronico, DbType.String, ParameterDirection.Input);
            parametros.Add("@prov_Telefono", item.prov_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@prov_UsuCreacion", 1, DbType.String, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Insertar_Proveedores, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_maqu_tbProveedores_VW> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<VW_maqu_tbProveedores_VW>(ScriptsDataBase.UDP_Listar_Proveedores, null, commandType: CommandType.StoredProcedure);
        }

        public int Update(VW_maqu_tbProveedores_VW item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();
            parametros.Add("@prov_Id", item.prov_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prov_Nombre", item.prov_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@prov_CorreoElectronico", item.prov_CorreoElectronico, DbType.String, ParameterDirection.Input);
            parametros.Add("@prov_Telefono", item.prov_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@prov_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_Proveedor, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
