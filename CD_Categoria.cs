using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Categoria
    {
        private CDConexion conexion = new CDConexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "MostrarCategorias";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string descripcion)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "InsertarCategorias";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void Editar(string nombre,string desc,int id)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EditarCategorias";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@id", id);



            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EliminarCategoria";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idCat", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public DataTable ListarCategorias()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "ListarCategorias";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;

        }


    }
}
