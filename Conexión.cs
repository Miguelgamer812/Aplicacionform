using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FacturacionMinimercado
{
    public class CD_Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection("Server = (local); Database = Facturacion; Integrated Security = true;");
            conexion.Open();
            return conexion;
        }
    }
}

