using System.Collections.Generic;
using System;
using System.Text;

namespace Datos
{
   public class Conexion
    {
        public static string Cn = @"Data Source = .\SQL_UAI; Initial Catalog = dbventas; Integrated Security = True";
        public static string CnArq = @"Data Source = .\SQL_UAI; Initial Catalog = Arq; Integrated Security = True";

        //  public static string Cn = @"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog = DBventas; Integrated Security = True;AttachDbFileName=|datadirectory|\DBas\DBventas.mdf ";
    }
}
