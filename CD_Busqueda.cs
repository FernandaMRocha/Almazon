using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Busqueda
    {
        CDConexion conexion = new CDConexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarPedido()
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "MostrarPedido";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void ReducirStock(int idprod, int cantidad)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "ReducirStock";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idprod", idprod);
            comando.Parameters.AddWithValue("@cantidad", cantidad);



            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void BajaPedido(int idprod)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "MoverRegistro";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Idpedido", idprod);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
