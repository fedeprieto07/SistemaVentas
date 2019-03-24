using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Ingreso
    {
        
            //Variables
            private int _Idingreso;
            private int _Idtrabajador;
            private int _Idproveedor;
            private DateTime _Fecha;
            private string _Tipo_Comprobante;
            private string _Serie;
            private string _Correlativo;
            private decimal _Igv;
            private string _Estado;

            //Propiedades
            public int Idingreso
            {
                get { return _Idingreso; }
                set { _Idingreso = value; }
            }


            public int Idtrabajador
            {
                get { return _Idtrabajador; }
                set { _Idtrabajador = value; }
            }


            public int Idproveedor
            {
                get { return _Idproveedor; }
                set { _Idproveedor = value; }
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


            public string Estado
            {
                get { return _Estado; }
                set { _Estado = value; }
            }
            //Constructores
            public Ingreso()
            {

            }

            public Ingreso(int idingreso, int idtrabajador, int idproveedor,
                DateTime fecha, string tipo_comprobante, string serie,
                string correlativo, decimal igv, string estado)
            {
                this.Idingreso = idingreso;
                this.Idtrabajador = idtrabajador;
                this.Idproveedor = idproveedor;
                this.Fecha = fecha;
                this.Tipo_Comprobante = tipo_comprobante;
                this.Serie = serie;
                this.Correlativo = correlativo;
                this.Igv = igv;
                this.Estado = estado;
            }
        }
}
