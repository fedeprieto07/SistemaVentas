using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Datos;
using System.Data;
using Datos22;

namespace Negocio
{
    public class nPresentacion
    {

        public static string Insertar(string nombre, string descripcion)
        {
            Presentacion Obj = new Presentacion();
            dPresentacion Pres = new dPresentacion();

            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Pres.Insertar(Obj);
        }


        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            Presentacion Obj = new Presentacion();
            dPresentacion Pres = new dPresentacion();

            Obj.Idpresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Pres.Editar(Obj);
        }

  
        public static string Eliminar(int idpresentacion)
        {
            Presentacion Obj = new Presentacion();
            dPresentacion Pres = new dPresentacion();

            Obj.Idpresentacion = idpresentacion;
            return Pres.Eliminar(Obj);
        }

   
        public static DataTable Mostrar()
        {
            return new dPresentacion().Mostrar();
        }


        public static DataTable BuscarNombre(string textobuscar)
        {
            Presentacion Obj = new Presentacion();
            dPresentacion Pres = new dPresentacion();

            Obj.TextoBuscar = textobuscar;
            return Pres.BuscarNombre(Obj);
        }




    }
}
