using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Proveedor
    {
        private int idProveedor;
        public int IdProveedor
        {
            get { return IdProveedor; }
            set { IdProveedor = value; }
        }


        private int codigoProveedor;
        public int CodigoProveedor
        {
            get { return CodigoProveedor; }
            set { CodigoProveedor = value; }
        }


        private string nombre;
        public string Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }


        private string direccion;
        public string Direccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }


        private int telefono;
        public int Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }


        private int rUC;
        public int RUC
        {
            get { return RUC; }
            set { RUC = value; }
        }


        private string correo;
        public string Correo
        {
            get { return Correo; }
            set { Correo = value; }
        }


        private string responsable;
        public string Responsable
        {
            get { return Responsable; }
            set { Responsable = value; }
        }


        private char estado;
        public char Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }



    }
}
