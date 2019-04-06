using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquitecturaBase
{
    public class Traductor{
        public static string Con = @"Data Source = (local)\SQLEXPRESS; Initial Catalog = Arq; Integrated Security = True";

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Lengaje");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Con;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_Lenguaje";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public string Insertar(String Lenguaje)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Con;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_Lenguaje";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@IdLenguaje";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Lenguaje";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Lenguaje;
                SqlCmd.Parameters.Add(ParNombre);

    


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

    }

}
