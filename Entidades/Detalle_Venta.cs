using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class Detalle_Venta
    {
        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_ingreso;
        private int _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Descuento;
        

        public int Iddetalle_venta
        {
            get { return _Iddetalle_venta; }
            set { _Iddetalle_venta = value; }
        }


        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }

        public int Iddetalle_ingreso
        {
            get { return _Iddetalle_ingreso; }
            set { _Iddetalle_ingreso = value; }
        }


        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public decimal Precio_Venta
        {
            get { return _Precio_Venta; }
            set { _Precio_Venta = value; }
        }


        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        //Constructores
        public Detalle_Venta()
        {

        }

        public Detalle_Venta(int iddetalle_venta, int idventa, int iddetalle_ingreso,
            int cantidad, decimal precio_venta, decimal descuento)
        {
            this.Iddetalle_venta = iddetalle_venta;
            this.Idventa = idventa;
            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Cantidad = cantidad;
            this.Precio_Venta = precio_venta;
            this.Descuento = descuento;
        }
    }
}
