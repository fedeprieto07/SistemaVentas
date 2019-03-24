using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Articulo
    {

        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _TextoBuscar;       

        public int Idarticulo
        {
            get { return _Idarticulo; }
            set { _Idarticulo = value; }
        }
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        
        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
        }
        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public Articulo()
        {

        }

        public Articulo(int idarticulo,string codigo,string nombre,string descripcion,int idcategoria,int idpresentacion,string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;

        }
    }
}
