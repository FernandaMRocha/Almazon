using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDConexion
    {
        private SqlConnection Conexion = new SqlConnection("data source = LAPTOP-SOPORTE\\SQLEXPRESS; initial catalog = BDSaw; user id = sa; password = 809947");
        //private SqlConnection Conexion = new SqlConnection("data source = Soporte-PC\\SQLEXPRESS; initial catalog = BDSaw; integrated seurity = true");
        //SqlConnection Conexion = new SqlConnection("server=Soporte-PC ; database= BDSaw ; integrated security = true");

        public SqlConnection AbriConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
