using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioBD : IServicioBD
    {
        SqlConnection con = new SqlConnection(@"Server=tcp:52.233.194.81\SQLEXPRESS,1433;Database=SensoresDB;User ID=ti1;Password=pass_mala;Trusted_Connection=False;Encrypt=False;Connection Timeout=60");
        //Creamos un nuevo comando
        SqlCommand miComm = new SqlCommand();


        public DataSet RecuperarLecturas()
        {
            //Le asignamos la conexion.
            miComm.Connection = con;
            //especificamos que el comando es un stored procedure
            miComm.CommandType = System.Data.CommandType.StoredProcedure;
            //y escribimos el nombre del stored procedure a invocar
            miComm.CommandText = "dbo.RecuperarLecturas";

            SqlDataAdapter miDA = new SqlDataAdapter(miComm);
            //Creamos un dataset para soportar los datos devueltos por el stored procedure
            DataSet ds = new DataSet();
            try
            {
                //Pedimos al Data Adapter que llene el dataset (Esto llama a nuestro comando)
                miDA.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int InsertarLectura(int estacion, decimal longitud, decimal latitud, int temperatura, int humedad, int presion, decimal velocidadViento, int nubes, DateTime fechaHora)
        {
            int id = -1;
            //Creamos un nuevo comando
            SqlCommand miComm = new SqlCommand();
            //Le asignamos la conexion.
            miComm.Connection = con;
            //especificamos que el comando es un stored procedure
            miComm.CommandType = System.Data.CommandType.StoredProcedure;
            //y escribimos el nombre del stored procedure a invocar
            miComm.CommandText = "dbo.InsertarLectura";

            //Creamos un nuevo parametro
            SqlParameter paramP1 = new SqlParameter();
            paramP1.ParameterName = "@estacion";
            paramP1.SqlDbType = System.Data.SqlDbType.Int;
            paramP1.Value = estacion;
            //Creamos un nuevo parametro
            SqlParameter paramP2 = new SqlParameter();
            paramP2.ParameterName = "@longitud";
            paramP2.SqlDbType = System.Data.SqlDbType.Decimal;
            if (longitud.ToString() == null) paramP2.Value = DBNull.Value;
            else paramP2.Value = longitud;

            SqlParameter paramP3 = new SqlParameter();
            paramP3.ParameterName = "@latitud";
            paramP3.SqlDbType = System.Data.SqlDbType.Decimal;
            if (latitud.ToString() == null) paramP3.Value = DBNull.Value;
            else paramP3.Value = latitud;

            SqlParameter paramP4 = new SqlParameter();
            paramP4.ParameterName = "@temperatura";
            paramP4.SqlDbType = System.Data.SqlDbType.Int;
            if (temperatura.ToString() == null) paramP4.Value = DBNull.Value;
            else paramP4.Value = temperatura;

            SqlParameter paramP5 = new SqlParameter();
            paramP5.ParameterName = "@humedad";
            paramP5.SqlDbType = System.Data.SqlDbType.Int;
            if (humedad.ToString() == null) paramP5.Value = DBNull.Value;
            else paramP5.Value = humedad;

            SqlParameter paramP6 = new SqlParameter();
            paramP6.ParameterName = "@presion";
            paramP6.SqlDbType = System.Data.SqlDbType.Int;
            if (presion.ToString() == null) paramP6.Value = DBNull.Value;
            else paramP6.Value = presion;

            SqlParameter paramP7 = new SqlParameter();
            paramP7.ParameterName = "@velocidadViento";
            paramP7.SqlDbType = System.Data.SqlDbType.Decimal;
            if (velocidadViento.ToString() == null) paramP7.Value = DBNull.Value;
            else paramP7.Value = velocidadViento;

            SqlParameter paramP8 = new SqlParameter();
            paramP8.ParameterName = "@nubes";
            paramP8.SqlDbType = System.Data.SqlDbType.Int;
            if (nubes.ToString() == null) paramP8.Value = DBNull.Value;
            else paramP8.Value = nubes;

            SqlParameter paramP9 = new SqlParameter();
            paramP9.ParameterName = "@fechaHora";
            paramP9.SqlDbType = System.Data.SqlDbType.DateTime;
            if (fechaHora.ToString() == null) paramP9.Value = DBNull.Value;
            else paramP9.Value = fechaHora;

            //Y los agregamos a la coleccion de parametros del comando myComm.Parameters.Add(myParam)
            miComm.Parameters.Add(paramP1);
            miComm.Parameters.Add(paramP2);
            miComm.Parameters.Add(paramP3);
            miComm.Parameters.Add(paramP4);
            miComm.Parameters.Add(paramP5);
            miComm.Parameters.Add(paramP6);
            miComm.Parameters.Add(paramP7);
            miComm.Parameters.Add(paramP8);
            miComm.Parameters.Add(paramP9);


            //¿Se abre la conexion?
            con.Open();

            //Creamos un nuevo DataAdapter con nuestro comando.
            SqlDataAdapter miDA = new SqlDataAdapter(miComm);

            try
            {
                id = Convert.ToInt32(miComm.ExecuteScalar());
                return id;

            }
            catch (Exception ex)
            {
                return id;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
