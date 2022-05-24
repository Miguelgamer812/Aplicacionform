using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Aplicaciónform
{
    public class CD_Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection("Server = (local); Database = Base_num2; Integrated Security = true;");
            conexion.Open();
            return conexion;
        }
    }
}
