using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;



namespace CapaDatos
{
     public class CD_Pedido
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

        //Editar Pedido
        public void Editar(int id, int cantidad)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EditarPedido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        //ELIMINAR
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EliminarPedido";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPedido", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        //LISTAR PEDIDO
        public DataTable ListarPedido()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "ListarPedido";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;

        }
        //LISTAR PEDIDO ENTREGADO
        public DataTable ListarBajas()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "ListarBajas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            conexion.CerrarConexion();
            return tabla;

        }


        public void GuardarPedido( int idprod, string nombre, int idcategoria, int idmarca, int Cantidad)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "GuardarPedido";
            comando.CommandType = CommandType.StoredProcedure;

            
            comando.Parameters.AddWithValue("@idprod", idprod);
            comando.Parameters.AddWithValue("@NombreProd", nombre);
            comando.Parameters.AddWithValue("@idcategoria", idcategoria);
            comando.Parameters.AddWithValue("@idmarca", idmarca);
            comando.Parameters.AddWithValue("@cantidad", Cantidad);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }



    }
}
