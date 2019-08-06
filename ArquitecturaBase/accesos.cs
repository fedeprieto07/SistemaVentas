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
        SqlConnection conexion_ventas = new SqlConnection(@"Data Source = .\SQL_UAI; Initial Catalog = DBventas; Integrated Security = True");
        SqlConnection conexion = new SqlConnection(@"Data Source =.\SQL_UAI; Initial Catalog = Arq; Integrated Security = True");
        public static string Con = @"Data Source =.\SQL_UAI; Initial Catalog = DBventas; Integrated Security = True";

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
            conexion.Close();
            return Lista;

        }

        public string Editar_acceso(int id, string nombre, string desc)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Con;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_acceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@id_acceso";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = id;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre_acceso";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = desc;
                SqlCmd.Parameters.Add(ParDescripcion);


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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
        public string Insertar_acceso(string nombre, string descripcion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Con;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_acceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@id_acceso";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre_acceso";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


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

        public Boolean CheckIf_polici_exists(int acceso,int politica)
        {

            conexion_ventas.Open();
            string query = "select COUNT (*) from accceso_politica where id_acceso = @acceso and id_politica = @politica";

            SqlCommand cmd = new SqlCommand(query, conexion_ventas);
            cmd.Parameters.AddWithValue("@acceso", acceso);
            cmd.Parameters.AddWithValue("@politica", acceso);


            string value = cmd.ExecuteScalar().ToString();


            if (value == "0") {
                return true; }

            else { return false; }


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
        public DataTable Mostrar_politicas()
        {
            DataTable DtResultado = new DataTable("politicas");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Con;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_politicas";
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

        public string Eliminar_acceso_politica(int acceso, int politica)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Con;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_acceso_politica";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@id_acceso";
                ParAcceso.SqlDbType = SqlDbType.Int;
                ParAcceso.Value = acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter parPolitica = new SqlParameter();
                parPolitica.ParameterName = "@id_politica";
                parPolitica.SqlDbType = SqlDbType.Int;
                parPolitica.Value = politica;
                SqlCmd.Parameters.Add(parPolitica);




                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


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


        public string Agregar_acceso_politica(int acceso, int politica)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Con;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_acceso_politica";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@id_acceso";
                ParAcceso.SqlDbType = SqlDbType.Int;
                ParAcceso.Value = acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter parPolitica = new SqlParameter();
                parPolitica.ParameterName = "@id_politica";
                parPolitica.SqlDbType = SqlDbType.Int;
                parPolitica.Value = politica;
                SqlCmd.Parameters.Add(parPolitica);




                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Agrego el Registro";


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


        public DataTable Mostrar_Accesos_politicas(int id_acceso)
        {
            DataTable DtResultado = new DataTable("Accesos_politicas");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Con;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_Accesos_politicas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter id_accesos = new SqlParameter();
                id_accesos.ParameterName = "@textobuscar";
                id_accesos.SqlDbType = SqlDbType.Int;
                id_accesos.Value = id_acceso;
                SqlCmd.Parameters.Add(id_accesos);

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
