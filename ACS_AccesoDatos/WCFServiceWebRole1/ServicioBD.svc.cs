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
        SqlConnection con = new SqlConnection(@"Server=tcp:88.88.88.88\SQLSERVEREXPRESS,1433;Database=Sensores;User ID=ti;Password=pass;Trusted_Connection=False;Encrypt=False;Connection Timeout=30");
        //Creamos un nuevo comando
        SqlCommand miComm = new SqlCommand();


        public DataSet RecuperarRegistros()
        {
            //Le asignamos la conexion.
            miComm.Connection = con;
            //especificamos que el comando es un stored procedure
            miComm.CommandType = System.Data.CommandType.StoredProcedure;
            //y escribimos el nombre del stored procedure a invocar
            miComm.CommandText = "dbo.RecuperarRegistros";

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

        public int InsertarRegistro(string estacion, decimal temperatura, decimal presion, string nivelUV, int luzAmbiente, DateTime fechaHora)
        {
            int id = -1;
            //Creamos un nuevo comando
            SqlCommand miComm = new SqlCommand();
            //Le asignamos la conexion.
            miComm.Connection = con;
            //especificamos que el comando es un stored procedure
            miComm.CommandType = System.Data.CommandType.StoredProcedure;
            //y escribimos el nombre del stored procedure a invocar
            miComm.CommandText = "dbo.InsertarRegistro";

            //Creamos un nuevo parametro
            SqlParameter paramP1 = new SqlParameter();
            paramP1.ParameterName = "@estacion";
            paramP1.SqlDbType = System.Data.SqlDbType.NVarChar;
            if (estacion == null) paramP1.Value = DBNull.Value;
            else paramP1.Value = estacion;
            //Creamos un nuevo parametro
            SqlParameter paramP2 = new SqlParameter();
            paramP2.ParameterName = "@temperatura";
            paramP2.SqlDbType = System.Data.SqlDbType.Decimal;
            if (temperatura.ToString() == null) paramP2.Value = DBNull.Value;
            else paramP2.Value = temperatura;

            SqlParameter paramP3 = new SqlParameter();
            paramP3.ParameterName = "@presion";
            paramP3.SqlDbType = System.Data.SqlDbType.Decimal;
            if (presion.ToString() == null) paramP3.Value = DBNull.Value;
            else paramP3.Value = presion;

            SqlParameter paramP4 = new SqlParameter();
            paramP4.ParameterName = "@nivelUV";
            paramP4.SqlDbType = System.Data.SqlDbType.NVarChar;
            if (nivelUV == null) paramP4.Value = DBNull.Value;
            else paramP4.Value = nivelUV;

            SqlParameter paramP5 = new SqlParameter();
            paramP5.ParameterName = "@luzAmbiente";
            paramP5.SqlDbType = System.Data.SqlDbType.Int;
            if (luzAmbiente.ToString() == null) paramP5.Value = DBNull.Value;
            else paramP5.Value = luzAmbiente;

            SqlParameter paramP6 = new SqlParameter();
            paramP6.ParameterName = "@fechaHora";
            paramP6.SqlDbType = System.Data.SqlDbType.DateTime;
            if (fechaHora.ToString() == null) paramP6.Value = DBNull.Value;
            else paramP6.Value = fechaHora;

            //Y los agregamos a la coleccion de parametros del comando myComm.Parameters.Add(myParam)
            miComm.Parameters.Add(paramP1);
            miComm.Parameters.Add(paramP2);
            miComm.Parameters.Add(paramP3);
            miComm.Parameters.Add(paramP4);
            miComm.Parameters.Add(paramP5);
            miComm.Parameters.Add(paramP6);


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
