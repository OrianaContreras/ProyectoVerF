using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using LibNegVerF;
using System.Data.SqlClient;
using System.Data;

namespace LibDataVerF
{
    public class BaseDato
    {
        private string strConn = ConfigurationManager.AppSettings["strConexion"];
        //private string strConn = "Data Source=UPR_404LAB_DCTE\\SQLSERVER2017DEV;Initial Catalog=DB_Amistades;User Id=sa;Password=Passw0rd";
        #region operaciones
        public Amigo ingresar(Amigo objAmigo)
        {

            SqlCommand cmd = new SqlCommand();
            try
            {
                //cmd.Connection = new SqlConnection("Data Source= motor_de_la_base_de_datos;Initial Catalog=nombre_de_la_base_de_datos;User Id=nombre_usuario;Password=clave_usuario");
                //cmd.Connection = new SqlConnection("Data Source=UPR_404LAB_DCTE\\SQLSERVER2017DEV;Initial Catalog=DB_Amistades;User Id=sa;Password=Passw0rd");
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_ingresar";

                cmd.Parameters.Add("@rut", SqlDbType.VarChar, 12).Value = objAmigo.Rut;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 20).Value = objAmigo.Nombre;
                cmd.Parameters.Add("@apPaterno", SqlDbType.VarChar, 20).Value = objAmigo.ApPaterno;
                cmd.Parameters.Add("@apMaterno", SqlDbType.VarChar, 20).Value = objAmigo.ApMaterno;
                cmd.Parameters.Add("@edad", SqlDbType.Int).Value = objAmigo.Edad;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = objAmigo.Direccion;
                cmd.Parameters.Add("@fono", SqlDbType.VarChar, 20).Value = objAmigo.Fono;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = objAmigo.Email;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                objAmigo.EsExito = true;
            }
            catch (SqlException ex)
            {
                objAmigo.Mensaje = "Excepcion Capturada: {0} " + ex.ToString();
                objAmigo.EsExito = false;
            }
            return objAmigo;
        }// fin ingresar

        public Amigo mostrar(Amigo objAmigo)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                //cmd.Connection = new SqlConnection("Data Source=UPR_404LAB_DCTE\\SQLSERVER2017DEV;Initial Catalog=DB_Amistades;User Id=sa;Password=Passw0rd");
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_mostrar";

                cmd.Parameters.Add("@Rut", SqlDbType.VarChar, 12).Value = objAmigo.Rut;

                cmd.Connection.Open();
                sda.Fill(objAmigo.Ds);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }
            catch (SqlException ex)
            {
                objAmigo.Mensaje = "Excepcion Capturada: {0} " + ex.ToString();
                //Console.WriteLine("Excepcion Capturada: {0} ", ex.ToString());
            }
            return objAmigo;
        }// fin mostrar

        public Amigo eliminar(Amigo objAmigo)
        {
            Console.WriteLine("soy eliminar");
  
            return objAmigo;
        }// fin eliminar

        public Amigo modificar(Amigo objAmigo)
        {
            Console.WriteLine("soy modificar");

            return objAmigo;
        }// fin modificar


        #endregion


    }//Fin Class BaseDato
}//Fin namespace
