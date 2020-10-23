using Curso.DAL;
using System;
using System.Data.SqlClient;
using Curso.DAL.EmpleadosDA;
using Entidades.DO;
using System.Data;
using System.Collections.Generic;

namespace DataProvider
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ejemplo1
            //  DataAccessLayer dal = new DataAccessLayer();
            //  System.Data.SqlClient.SqlConnection conn = dal.obtenerConexion();



            //Ejemplo2
            //SqlCommandDA cda = new SqlCommandDA();
            //cda.executeNonQuery();

            //Ejemplo3
            //cda.executeScalar();

            //Ejemplo4
            // cda.executeReader();

            //Ejemplo5

            //DataSetCustom ejemploDS = new DataSetCustom();
            //System.Data.DataSet librosDS =  ejemploDS.getLibros();



            //DataAccessLayer dal = new DataAccessLayer();
            //System.Data.SqlClient.SqlConnection conn = dal.obtenerConexion();
            //SqlTransaction tran = conn.BeginTransaction();
            //try
            //{

            //    tran.Commit();
            //}
            //catch (Exception ex)
            //{
            //    tran.Rollback();
            //}
            //finally
            //{
            //    tran.Dispose();
            //    conn.Close();
            //    conn.Dispose();
            //}


            //Paginado

            EmpleadosDA empDA = new EmpleadosDA();
            EmpleadosFilterDO filter = new EmpleadosFilterDO();
            List<EmpleadosDO> resultado = new List<EmpleadosDO>();
            filter.SEXO = "H";
            filter.PaginateProperties = new PaginatePropertiesDO();
            filter.PaginateProperties.PageSize = 2;
            filter.PaginateProperties.PageIndex = 2;
            filter.PaginateProperties.Order = 1;
            filter.PaginateProperties.SortBy = "APELLIDOS";

            DataSet ds = empDA.getEmpleadosByFilter(filter);
            DataTable tblempleados;
            tblempleados = ds.Tables[0];
            foreach (DataRow dr in tblempleados.Rows)
            {
                EmpleadosDO emp = new EmpleadosDO();
                emp.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                emp.APELLIDOS = Convert.ToString(dr["APELLIDOS"]);
                resultado.Add(emp);

            }




        }
    }
}
