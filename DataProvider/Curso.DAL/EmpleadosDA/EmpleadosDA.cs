using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DO;
using System.Data.SqlClient;
using System.Data;

namespace Curso.DAL.EmpleadosDA
{
    public  class EmpleadosDA
    {
        public DataSet getEmpleadosByFilter(EmpleadosFilterDO filter) {

            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using (DataAccessLayer da = new DataAccessLayer())
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Empleados_GetByFilter";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = da.obtenerConexion();
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre", Value = filter.NOMBRE, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Apellidos", Value = filter.APELLIDOS, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FechaNacimiento", Value = filter.F_NACIMIENTO, SqlDbType = SqlDbType.DateTime });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Sexo", Value = filter.SEXO, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Salario", Value = filter.SALARIO, SqlDbType = SqlDbType.Decimal });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Cargo", Value = filter.CARGO, SqlDbType = SqlDbType.VarChar });
                    //Parametros del Paginado

                    cmd.Parameters.Add(new SqlParameter(){  ParameterName = "@PageSize", SqlDbType = SqlDbType.Int, Value = filter.PaginateProperties == null ? null : filter.PaginateProperties.PageSize });
                    cmd.Parameters.Add(new SqlParameter(){  ParameterName = "@PageIndex", SqlDbType = SqlDbType.Int, Value = filter.PaginateProperties == null ? null : filter.PaginateProperties.PageIndex });
                    cmd.Parameters.Add(new SqlParameter(){  ParameterName = "@SortBy", SqlDbType = SqlDbType.VarChar, Value = filter.PaginateProperties == null ? null : filter.PaginateProperties.SortBy });
                    cmd.Parameters.Add(new SqlParameter(){ ParameterName = "@Order", SqlDbType = SqlDbType.Int, Value =filter.PaginateProperties == null ? null : filter.PaginateProperties.Order });

                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && filter.PaginateProperties != null)
                        filter.PaginateProperties.RecordsCount = Convert.ToInt32(ds.Tables[0].Rows[0]["total_records"]);
                    return ds;
                }
            }
        }
    }
}