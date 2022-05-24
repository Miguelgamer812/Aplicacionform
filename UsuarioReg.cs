using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Aplicaciónform
{
    public class UsuarioReg
    {
        public static int CrearCuentas(String pUsuario, string PContraseña)
        {
            int resultado = 0;
            SqlConnection conn = CD_Conexion.Conectar();
            SqlCommand comando = new SqlCommand(String.Format("Insert Into Usuario(Nombre,Contraseña) values ('{0}', PwdEncrypt('{1}'))", pUsuario, PContraseña), conn);

            resultado = comando.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }
        public static int Autentificacion(string pUsuario, string pContraseña)
        {
            int resultado = -1;
            SqlConnection conexion = CD_Conexion.Conectar();
            SqlCommand comando = new SqlCommand(string.Format("select * From Usuario where Nombre = '{0}' and PwdCompare('{1}', Contraseña)=1", pUsuario, pContraseña), conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                resultado = 50;
            }
            conexion.Close();
            return resultado;
        }
    }
}
