using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Categoria
    {

        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;


        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
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

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructor Vacío
        public Categoria()
        {

        }
        //Constructor con parámetros
        public Categoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;

        }
    }
}
