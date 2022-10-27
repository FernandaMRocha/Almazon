using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;



namespace CapaDatos
{
    public class CDEmpleado
    {

        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;
        private String Email, Nombres, Contraseña;
        private String Mensaje;
        private SqlCommand Comando = new SqlCommand();

        public String RecuperarContraseña(String Cel)
        {
            Comando.Connection = conexion.AbriConexion();
            Comando.CommandText = "Select * from Usuario where Cel=" + Cel;
            leer = Comando.ExecuteReader();
            if (leer.Read()== true)
            {
                Email = leer["Email"].ToString();
                Nombres = leer["Nombres"].ToString() + "," + leer["Apellidopaterno"].ToString();
                Contraseña = leer["Contraseña"].ToString();
                //Enviar Email
                EnviarEmail();

                Mensaje = "Estimado"+Nombres+",Se le ah enviado su contraseña a su correo:"+Email+":Verifique su bandeja de entrada";
                leer.Close();

            }
            else
            {
                Mensaje = "No existe datos...";
            }
            return Mensaje;
        }
        public void EnviarEmail()
        {
            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("jramirez@callcom.mx");
            Correo.To.Add(Email);
            Correo.Subject = ("RECUPERAR CONTRASEÑA SYSTEM");
            Correo.Body = "Hola,"+Nombres+"Usted solicito recuperar su contraseña\nSu contraseña es:"+Contraseña;
            //SMTP
            SmtpClient ServerMail = new SmtpClient();
            ServerMail.Credentials = new NetworkCredential("jramirez@callcom.mx", "Callcom1000");
            ServerMail.Host = "mail.callcom.mx";
            ServerMail.Port = 587;
            ServerMail.EnableSsl = true;
            try
            {
                ServerMail.Send(Correo);
            }
            catch (Exception ex)
            {

               
            }
            Correo.Dispose();
        }

        public SqlDataReader iniciarSesion(string user,string pass)
        {
            
            SqlCommand comando = new SqlCommand("SPIniciarSesion",conexion.AbriConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@password", pass);
            leer = comando.ExecuteReader();

            return leer;
        }

    }

}
