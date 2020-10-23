using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.DAL
{
    public class DataSetCustom
    {
        public DataSetCustom()
        {
            DataAdapterCustom adapter = new DataAdapterCustom();
            this.adaptador = adapter.GetAdapter();
        }
        public SqlDataAdapter adaptador;

        public DataSet getLibros()
        {
            DataSet librosDS = new DataSet();
            adaptador.Fill(librosDS);
            return librosDS;
        }
        
    }
}
