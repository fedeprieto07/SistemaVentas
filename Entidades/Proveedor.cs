using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Proveedor
    {
        private int _Idproveedor;

        private string _Razon_Social;

        private string _Sector_Comercial;

        private string _Tipo_Documento;

        private string _Num_Documento;

        private string _Direccion;

        private string _Telefono;

        private string _Email;

        private string _Url;

        private string _TextoBuscar;



        //Propiedades
        public int Idproveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }


        public string Razon_Social
        {
            get { return _Razon_Social; }
            set { _Razon_Social = value; }
        }


        public string Sector_Comercial
        {
            get { return _Sector_Comercial; }
            set { _Sector_Comercial = value; }
        }


        public string Tipo_Documento
        {
            get { return _Tipo_Documento; }
            set { _Tipo_Documento = value; }
        }

        public string Num_Documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public Proveedor()
        {

        }
        public Proveedor(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url, string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.Razon_Social = razon_social;
            this.Sector_Comercial = sector_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textobuscar;

        }



    }
}
