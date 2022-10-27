using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_USUARIO
    {
        private CDConexion conexion = new CDConexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "MostrarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void InsertarUsuario(string Cel, string Nombre, string ApePat, string ApeMat, string Cargo, string Email, string Contrasena)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "InsertarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cel", Cel);
            comando.Parameters.AddWithValue("@Nombres", Nombre);
            comando.Parameters.AddWithValue("@ApellidoPaterno", ApePat);
            comando.Parameters.AddWithValue("@ApellidoMaterno", ApeMat);
            comando.Parameters.AddWithValue("@Cargo", Cargo);
            comando.Parameters.AddWithValue("@Email", Email);
            comando.Parameters.AddWithValue("@Contraseña", Contrasena);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void Editar(string Rfc, string Nombre, string ApePat, string ApeMat, string Cargo, string Email, string Contrasena,int id)
        {

            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EditarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Rfc", Rfc);
            comando.Parameters.AddWithValue("@Nombres", Nombre);
            comando.Parameters.AddWithValue("@ApellidoPaterno", ApePat);
            comando.Parameters.AddWithValue("@ApellidoMaterno", ApeMat);
            comando.Parameters.AddWithValue("@Cargo", Cargo);
            comando.Parameters.AddWithValue("@Email", Email);
            comando.Parameters.AddWithValue("@Contraseña", Contrasena);
            comando.Parameters.AddWithValue("@Id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbriConexion();
            comando.CommandText = "EliminarUsuario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@iduser", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
       

    }

    
}

