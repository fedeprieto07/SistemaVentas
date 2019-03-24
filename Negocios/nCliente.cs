using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Datos;
using System.Data;
using Datos22;
namespace Negocio
{
    public class nCliente
    {

        public static string Insertar(string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento,
            string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            Cliente Obj = new Cliente();
            dCliente dObj = new dCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return dObj.Insertar(Obj);
        }

    
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento,
            string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            Cliente Obj = new Cliente();
            dCliente dObj = new dCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return dObj.Editar(Obj);
        }

   
        public static string Eliminar(int idcliente)
        {
            Cliente Obj = new Cliente();
            dCliente dObj = new dCliente();
            Obj.Idcliente = idcliente;
            return dObj.Eliminar(Obj);
        }

       
        public static DataTable Mostrar()
        {
            return new dCliente().Mostrar();
        }

      

        public static DataTable BuscarApellidos(string textobuscar)
        {
            Cliente Obj = new Cliente();
            dCliente dObj = new dCliente();
            Obj.TextoBuscar = textobuscar;
            return dObj.BuscarApellidos(Obj);
        }

 

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            Cliente Obj = new Cliente();
            dCliente dObj = new dCliente();
            Obj.TextoBuscar = textobuscar;
            return dObj.BuscarNum_Documento(Obj);
        }
    }
}
