using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using Datos;
using Datos22;
namespace Negocio
{
   public class nVenta
    {
        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha,
            string tipo_comprobante, string serie, string correlativo, decimal igv,
            DataTable dtDetalles)
        {
            Venta Obj = new Venta();
            dVenta objv = new dVenta();
            Obj.Idcliente = idcliente;
            Obj.Idtrabajador = idtrabajador;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            List<Detalle_Venta> detalles = new List<Detalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                Detalle_Venta detalle = new Detalle_Venta();
                detalle.Iddetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());
                detalles.Add(detalle);
            }
            return objv.Insertar(Obj, detalles);
        }
        public static string Eliminar(int idventa)
        {
            Venta Obj = new Venta();
            dVenta objv = new dVenta();

            Obj.Idventa = idventa;
            return objv.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dVenta().Mostrar();
        }


        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            dVenta Obj = new dVenta();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            dVenta Obj = new dVenta();
            return Obj.MostrarDetalle(textobuscar);
        }
        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            dVenta Obj = new dVenta();
            return Obj.MostrarArticulo_Venta_Nombre(textobuscar);
        }
        public static DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            dVenta Obj = new dVenta();
            return Obj.MostrarArticulo_Venta_codigo(textobuscar);
        }
    }
}
