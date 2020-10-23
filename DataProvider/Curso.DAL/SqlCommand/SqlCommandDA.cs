using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.DAL
{
    public class SqlCommandDA
    {
        public int executeNonQuery()
        {
            try
            {
                using(DataAccessLayer da = new DataAccessLayer()){
                    SqlConnection conn = da.obtenerConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE [Usuario] SET Telefono=011 WHERE Nombre LIKE 'R%' ";
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("Registros afectados :"+i.ToString() );
                    return i;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
                return -1;  
            }
        
        }
        public void executeScalar()
        {
            try
            {
                using (DataAccessLayer da = new DataAccessLayer())
                {
                    SqlConnection conn = da.obtenerConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT SALARIO,nombre FROM Empleados";
                    object result = cmd.ExecuteScalar();
                    Console.WriteLine("El salario es :$" + Convert.ToDecimal(result));
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
                
            }

        }
        public void executeReader()
        {
            try
            {
                using (DataAccessLayer da = new DataAccessLayer())
                {
                    SqlConnection conn = da.obtenerConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Usuario_GetByFilter";
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre", Value = "Isaac", SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Apellido", Value = "Hatfield", SqlDbType = SqlDbType.VarChar });
                    SqlDataReader result = cmd.ExecuteReader();
                    
                    while (result.Read())
                    {
                        Console.WriteLine(result.GetString(1)+" "+result.GetString(2) + " " + result.GetString(3));
                    }
                    result.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);

            }

        }


    }
}
