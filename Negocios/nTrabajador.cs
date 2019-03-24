using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Datos;
using System.Data;
using Datos22;
namespace Negocio
{
    public class nTrabajador
    {
        public static string Insertar(string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string num_documento,
            string direccion, string telefono, string email, string acceso,
            string usuario, string password)
        {
            Trabajador Obj = new Trabajador();
            dTrabajador dObj = new dTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return dObj.Insertar(Obj);
        }

     
        public static string Editar(int idtrabajador, string nombre, string apellidos,
            string sexo,
            DateTime fecha_nacimiento, string num_documento,
            string direccion, string telefono, string email, string acceso, string usuario,
            string password)
        {
            Trabajador Obj = new Trabajador();
            dTrabajador dObj = new dTrabajador();

            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return dObj.Editar(Obj);
        }

      
        public static string Eliminar(int idtrabajador)
        {
            Trabajador Obj = new Trabajador();
            dTrabajador dObj = new dTrabajador();

            Obj.Idtrabajador = idtrabajador;
            return dObj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dTrabajador().Mostrar();
        }



        public static DataTable BuscarApellidos(string textobuscar)
        {
            Trabajador Obj = new Trabajador();
            dTrabajador dObj = new dTrabajador();

            Obj.TextoBuscar = textobuscar;
            return dObj.BuscarApellidos(Obj);
        }

        
       

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            Trabajador Obj = new Trabajador();
            dTrabajador dObj = new dTrabajador();

            Obj.TextoBuscar = textobuscar;
            return dObj.BuscarNum_Documento(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            Trabajador Obj = new Trabajador();
            dTrabajador dObj = new dTrabajador();

            Obj.Usuario = usuario;
            Obj.Password = password;
            return dObj.Login(Obj);
        }
    }
}
