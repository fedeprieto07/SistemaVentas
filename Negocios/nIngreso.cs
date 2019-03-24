using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using Datos;
using Datos22;

namespace Negocio
{
    public class nDetalle_Ingreso
    {
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha,
            string tipo_comprobante, string serie, string correlativo, decimal igv,
            string estado, DataTable dtDetalles)
        {
            dIngreso objin = new dIngreso();
            Ingreso Obj = new Ingreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            List<Detalle_Ingreso> detalles = new List<Detalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                Detalle_Ingreso detalle = new Detalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);
            }
            return objin.Insertar(Obj, detalles);
        }
        public static string Anular(int idingreso)
        {
            Ingreso Obj = new Ingreso();
            dIngreso objin = new dIngreso();

            Obj.Idingreso = idingreso;
            return objin.Anular(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dIngreso().Mostrar();
        }

   

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            dIngreso objin = new dIngreso();

            Ingreso Obj = new Ingreso();
            return objin.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            dIngreso objin = new dIngreso();

            Ingreso Obj = new Ingreso();
            return objin.MostrarDetalle(textobuscar);
        }

   
    }
}
