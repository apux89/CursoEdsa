using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DO
{
    public class EmpleadosDO
    {
       public int? ID_EMPLEADO { get; set; }
       public string NOMBRE { get; set; }
       public string APELLIDOS  { get; set; }
       public DateTime? F_NACIMIENTO { get; set; }
       public string SEXO { get; set; }
       public string CARGO { get; set; }
       public Decimal? SALARIO { get; set; }
    }
}
