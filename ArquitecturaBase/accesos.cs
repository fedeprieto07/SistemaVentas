using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquitecturaBase
{
   public class accesos
    {
        SqlConnection conexion_ventas = new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = DBventas; Integrated Security = True");
        SqlConnection conexion = new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = Arq; Integrated Security = True");
        public static string Con = @"Data Source = (local)\SQLEXPRESS; Initial Catalog = DBventas; Integrated Security = True";

        public List<String> list_accesps(string id_trabajador)
        {

            conexion.Open();
            string query = "SELECT p.nombre_politica FROM[DBventas].[dbo].[trabajador] as t inner join[DBventas].[dbo].[Acceso] as a on(t.acceso = a.id_acceso) inner join[DBventas].[dbo].[Accceso_Politica] as b on(a.id_acceso = b.id_acceso) inner join[DBventas].[dbo].[Politica] as p on(b.id_politica = p.id_politica) where t.idtrabajador = @idtrabajador";


            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@idtrabajador", id_trabajador);
            SqlDataReader dr = cmd.ExecuteReader();

            List<String> Lista = new List<String>();
            int number;

            while (dr.Read())
            {

                Lista.Add(dr["nombre_politica"].ToString());
            }

            return Lista;

        }

        public int get_id_acceso(string nombre_acceso)
        {

            conexion_ventas.Open();
            string query = "select id_acceso from Acceso where nombre_Acceso = @nombre_acceso";
            int id = 0;
            SqlCommand cmd = new SqlCommand(query, conexion_ventas);
            cmd.Parameters.AddWithValue("@nombre_acceso", nombre_acceso);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                id = Convert.ToInt32(dr["id_acceso"]);
            }
            
            conexion_ventas.Close();
            return id;

        }

        public string get_nombre_acceso(int id_ingreso)
        {

            conexion_ventas.Open();
            string query = "select nombre_acceso from Acceso where id_acceso = @id_acceso";
            string nombre = "";
            SqlCommand cmd = new SqlCommand(query, conexion_ventas);
            cmd.Parameters.AddWithValue("@id_acceso", id_ingreso);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                nombre = dr["nombre_acceso"].ToString();
            }

            conexion_ventas.Close();
            return nombre;

        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Accesos");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Con;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_Accesos";
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

    }
}
