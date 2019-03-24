using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Datos;
using System.Data;
using Datos22;
namespace Negocio
{
    public class nProveedor
    {
        public static string Insertar(string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento,
            string direccion, string telefono, string email, string url)
        {
            Proveedor Obj = new Proveedor();
            dProveedor dObj = new dProveedor();
            Obj.Razon_Social = razon_proveedor;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            return dObj.Insertar(Obj);
        }

 
        public static string Editar(int idproveedor, string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento,
            string direccion, string telefono, string email, string url)
        {
            Proveedor Obj = new Proveedor();
            dProveedor dObj = new dProveedor();

            Obj.Idproveedor = idproveedor;
            Obj.Razon_Social = razon_proveedor;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return dObj.Editar(Obj);
        }


        public static string Eliminar(int idproveedor)
        {
            Proveedor Obj = new Proveedor();
            dProveedor dObj = new dProveedor();

            Obj.Idproveedor = idproveedor;
            return dObj.Eliminar(Obj);
        }

        
        public static DataTable Mostrar()
        {
            return new dProveedor().Mostrar();
        }

     

        public static DataTable BuscarRazon_social(string textobuscar)
        {
            Proveedor Obj = new Proveedor();
            dProveedor dObj = new dProveedor();

            Obj.TextoBuscar = textobuscar;
            return dObj.BuscarRazon_Social(Obj);
        }

  

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            Proveedor Obj = new Proveedor();
            dProveedor dObj = new dProveedor();

            Obj.TextoBuscar = textobuscar;
            return dObj.BuscarNum_Documento(Obj);
        }

    }
}
