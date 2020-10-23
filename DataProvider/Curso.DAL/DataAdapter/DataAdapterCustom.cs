using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.DAL
{
    public class DataAdapterCustom
    {
        public DataAdapterCustom()
        {
            DataAccessLayer da = new DataAccessLayer();
            con = da.obtenerConexion();
        }
        public SqlConnection con;
        public SqlDataAdapter GetAdapter()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = con;
            cmdSelect.CommandType = CommandType.Text;
            cmdSelect.CommandText = "SELECT * FROM Libros";
            adapter.SelectCommand = cmdSelect;

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = con;
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.CommandText = "Libros_Updeate";
            cmdUpdate.Parameters.Add(new SqlParameter() { ParameterName = "@Codigo", Value = "3", SqlDbType = SqlDbType.Int });
            cmdUpdate.Parameters.Add(new SqlParameter() { ParameterName = "@Titulo", Value = "Libro 1", SqlDbType = SqlDbType.VarChar });
            cmdUpdate.Parameters.Add(new SqlParameter() { ParameterName = "@Autor", Value = "Autor", SqlDbType = SqlDbType.VarChar });
            cmdUpdate.Parameters.Add(new SqlParameter() { ParameterName = "@NombreEditorial", Value = "Planeta", SqlDbType = SqlDbType.VarChar });
            cmdUpdate.Parameters.Add(new SqlParameter() { ParameterName = "@Precio", Value = 1500, SqlDbType = SqlDbType.Decimal });
            adapter.UpdateCommand = cmdUpdate;

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = con;
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandText = "Editoriales_Insert";
            cmdInsert.Parameters.Add(new SqlParameter() { ParameterName = "@NombreEditorial", Value = "Editorial1", SqlDbType = SqlDbType.VarChar });
            adapter.InsertCommand = cmdInsert;



            return adapter;
        }

        
    }
}
