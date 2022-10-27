using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CDConexion conexion = new CDConexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string nombre, string desc, int marca, int stock, int Categoria)
        {
            
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "InsertarPorducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@categoria", Categoria);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void Editar(string nombre,string desc,int marca,int stock,int id,int Categoria)
        {
            
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@categoria", Categoria);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void Eliminar (int id)
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro", id);

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
        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "ListarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public void Selecprod(int id)
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "SeleccionarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();


        }

       




    }
}
