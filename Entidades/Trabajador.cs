using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Trabajador
    {
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

        //Propiedades

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Acceso
        {
            get { return _Acceso; }
            set { _Acceso = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public string Num_Documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }


        public DateTime Fecha_Nacimiento
        {
            get { return _Fecha_Nacimiento; }
            set { _Fecha_Nacimiento = value; }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }


        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }


        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public int Idtrabajador
        {
            get { return _Idtrabajador; }
            set { _Idtrabajador = value; }
        }

        //Constructores
        public Trabajador()
        {

        }

        public Trabajador(int idtrabajador, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string num_documento, string direccion, string telefono,
            string email, string acceso, string usuario, string password, string textobuscar)
        {
            this.Idtrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;

        }
    }
}
