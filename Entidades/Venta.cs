using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Venta
    {
        private int _Idventa;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;

        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }

        public int Idcliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }

        public int Idtrabajador
        {
            get { return _Idtrabajador; }
            set { _Idtrabajador = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Tipo_Comprobante
        {
            get { return _Tipo_Comprobante; }
            set { _Tipo_Comprobante = value; }
        }

        public string Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

        public string Correlativo
        {
            get { return _Correlativo; }
            set { _Correlativo = value; }
        }


        public decimal Igv
        {
            get { return _Igv; }
            set { _Igv = value; }
        }
        //Constructores 
        public Venta()
        {

        }
        public Venta(int idventa, int idcliente, int idtrabajador,
            DateTime fecha, string tipo_comprobante, string serie,
            string correlativo, decimal igv)
        {
            this.Idventa = idventa;
            this.Idcliente = idcliente;
            this.Idtrabajador = idtrabajador;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;

        }
    }
}
