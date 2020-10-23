using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Curso.DAL
{
    public class DataAccessLayer : IDisposable
    {

        public DataAccessLayer() {
            connection = new SqlConnection();
        }
       
        public SqlConnection connection;
        public SqlConnection obtenerConexion()
        {
              
              try
              {
                connection.ConnectionString = "Data Source=localhost\\SQLExpress;"+
                    "Initial Catalog=CURSO2020;Integrated Security=true;";
                connection.Open();
                Console.WriteLine("Se creo la conexión exitosamente");
             
                
              return connection;
              }
              catch (Exception e)
              {
                  Console.WriteLine("Message: " + e.Message);
              return null;
              }
            
         }
        public void Dispose()
        {
            if (connection.State == System.Data.ConnectionState.Open){
                connection.Close();
                connection.Dispose();
            }
}
    }
}
