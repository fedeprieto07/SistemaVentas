using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ArquitecturaBase
{
    public class Bitacora
    {

        public static string Cn = @"Data Source = (local)\SQLEXPRESS; Initial Catalog = Arq; Integrated Security = True";
        //  public static string Cn = @"Data Source =.\SQLEXPRESS; Initial Catalog = Arq; Integrated Security = True;AttachDbFileName=|datadirectory|\Arq.mdf ";
        public void logger(string Mensaje, int Nivel) { 
        SqlConnection con = new SqlConnection(Cn);
            con.Open();
            SqlCommand com = new SqlCommand("Insert Into Bitacora (FechaIncidente, Nivel, Mensaje) VALUES (@FechaIncidente, @Nivel, @Mensaje)", con);
              com.Parameters.AddWithValue("@FechaIncidente", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.AddWithValue("@Nivel", Nivel); 
            com.Parameters.AddWithValue("@Mensaje", Mensaje);
            try
            {
                com.ExecuteNonQuery();
                com.Parameters.Clear();
                con.Close();
            }
            catch (Exception n)
            {
                throw n;
            }
        }
    }
}
