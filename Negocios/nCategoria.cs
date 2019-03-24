using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using Datos;
namespace Negocio
{
    public class nCategoria
    {
        public static string Insertar(string nombre, string descripcion)
        {
            Categoria Obj = new Categoria();
            dCategoria cat = new dCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return cat.Insertar(Obj);
        }

        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            dCategoria cat = new dCategoria();

            Categoria Obj = new Categoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return cat.Editar(Obj);
        }

        public static string Eliminar(int idcategoria)
        {
            dCategoria cat = new dCategoria();

            Categoria Obj = new Categoria();
            Obj.Idcategoria = idcategoria;
            return cat.Eliminar(Obj);
        }

 
        public static DataTable Mostrar()
        {

            return new dCategoria().Mostrar();
        }


        public static DataTable BuscarNombre(string textobuscar)
        {
            Categoria Obj = new Categoria();
            dCategoria cat = new dCategoria();

            Obj.TextoBuscar = textobuscar;
            return cat.BuscarNombre(Obj);
        }
    }
}
