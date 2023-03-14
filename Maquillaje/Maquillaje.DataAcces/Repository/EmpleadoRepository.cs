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
        public int DeleteConfirmed(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();

            parametros.Add("@empe_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Eliminar_Empleado, parametros, commandType: CommandType.StoredProcedure);
        }

        public tbEmpleados find(int? id)
        {
            using var db = new AndreasContext();
            var listado = db.tbEmpleados.Find(id);
            return listado;
        }

        public int Update(tbEmpleados item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();

            DateTime fecha = Convert.ToDateTime(item.empe_FechaNacimiento);
            string fechaNacimiento = fecha.ToString("yyyy-M-dd");

            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Nombres", item.empe_Nombres, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Apellidos  ", item.empe_Apellidos, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Identidad", item.empe_Identidad, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_FechaNacimiento",fechaNacimiento, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Sexo", item.empe_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("@estacivi_Id", item.estacivi_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Direccion", item.empe_Direccion, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Telefono", item.empe_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_CorreoElectronico", item.empe_CorreoElectronico, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_UsuModificacion", 1, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirstOrDefault<int>(ScriptsDataBase.UDP_Editar_Empleado, parametros, commandType: CommandType.StoredProcedure);
        }

        public int Insert(tbEmpleados item)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);

            var parametros = new DynamicParameters();

            DateTime fecha = Convert.ToDateTime(item.empe_FechaNacimiento);
            string fechaNacimiento = fecha.ToString("yyyy-M-dd hh:mm:ss");

            parametros.Add("@empe_Nombres", item.empe_Nombres, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Apellidos", item.empe_Apellidos, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Identidad", item.empe_Identidad, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_FechaNacimiento", fechaNacimiento, DbType.DateTime, ParameterDirection.Input);
            parametros.Add("@empe_Sexo", item.empe_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("@estacivi_Id", item.estacivi_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Direccion", item.empe_Direccion, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Telefono", item.empe_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_CorreoElectronico", item.empe_CorreoElectronico, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_UsuCreacion", "1", DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_UsuCreacion", 1, DbType.String, ParameterDirection.Input);

            return db.QueryFirst<int>(ScriptsDataBase.UDP_Insertar_Empleado, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<tbEmpleados> List()
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            return db.Query<tbEmpleados>(ScriptsDataBase.UDP_Listar_Empleado, null, commandType: CommandType.StoredProcedure);
        }

        //public int Update(tbEmpleados item)
        //{
        //    using var db = new SqlConnection(AndreasContext.ConnectionString);

        //    var parametros = new DynamicParameters();

        //    parametros.Add("@empe_Nombres", item.empe_Nombres, DbType.String, ParameterDirection.Input);
        //    parametros.Add("@empe_Apellidos", item.empe_Apellidos, DbType.String, ParameterDirection.Input);
        //    parametros.Add("@empe_Identidad", item.empe_Identidad, DbType.String, ParameterDirection.Input);
        //    parametros.Add("@empe_FechaNacimiento", item.empe_FechaNacimiento, DbType.String, ParameterDirection.Input);
        //    parametros.Add("@empe_Sexo", item.empe_Sexo, DbType.String, ParameterDirection.Input);
        //    parametros.Add("@estacivi_Id", item.estacivi_Id, DbType.Int32, ParameterDirection.Input);
        //    parametros.Add("@muni_Id", item.muni_Id, DbType.String, ParameterDirection.Input);
        //    parametros.Add("@empe_Direccion", item.empe_Direccion, DbType.String, ParameterDirection.Input);
        //    parametros.Add("@empe_Telefono", item.empe_Telefono, DbType.String, ParameterDirection.Input);
        //    parametros.Add("@empe_CorreoElectronico", item.empe_CorreoElectronico, DbType.String, ParameterDirection.Input);

        //    return db.QueryFirst<int>(ScriptsDataBase.UDP_Editar_Empleado, parametros, commandType: CommandType.StoredProcedure);
        //}

        public IEnumerable<VW_maqu_tbEmpleados_DDLMunicipios> GetMuni_IdByEmpe_Id(int id)
        {
            using var db = new SqlConnection(AndreasContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@empe_Id", id, DbType.Int32, ParameterDirection.Input);
            return db.Query<VW_maqu_tbEmpleados_DDLMunicipios>(ScriptsDataBase.UDP_Editar_Empleado_Municipios_DDL, parametros, commandType: CommandType.StoredProcedure);
        }
    }
}
