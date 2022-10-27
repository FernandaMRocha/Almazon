using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
   public class CD_Marca
    {
        private CDConexion conexion = new CDConexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "MostrarMarcas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string descripcion)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "InsertarMarcas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void Editar(string nombre, int id)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EditarMarcas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@Id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EliminarMarcas";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idmarca", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public DataTable ListarMarcas()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "ListarMarcas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;

        }


    }


}
