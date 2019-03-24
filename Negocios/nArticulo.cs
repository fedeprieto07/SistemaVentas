using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Datos;
using System.Data;
using Datos22;

namespace Entidades
{
    public class nArticulo
    {



        public static string Insertar(string codigo, string nombre, string descripcion, int idcategoria, int idpresentacion)
        {
            Articulo Obj = new Articulo();
            dArticulo Art = new dArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;

            return Art.Insertar(Obj);
        }

    
        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, int idcategoria, int idpresentacion)
        {
            Articulo Obj = new Articulo();
            dArticulo Art = new dArticulo();

            Obj.Idarticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            return Art.Editar(Obj);
        }


        public static string Eliminar(int idarticulo)
        {
            Articulo Obj = new Articulo();
            dArticulo Art = new dArticulo();

            Obj.Idarticulo = idarticulo;
            return Art.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dArticulo().Mostrar();
        }

   
        public static DataTable BuscarNombre(string textobuscar)
        {
            Articulo Obj = new Articulo();
            dArticulo Art = new dArticulo();

            Obj.TextoBuscar = textobuscar;
            return Art.BuscarNombre(Obj);
        }
        public static DataTable Stock_Articulos()
        {
            return new dArticulo().Stock_Articulos();
        }

    }
}
