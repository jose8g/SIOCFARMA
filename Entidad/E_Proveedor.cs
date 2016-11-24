using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Proveedor
    {
        private int IdProveedor;

        public int IdProveedor1
        {
            get { return IdProveedor; }
            set { IdProveedor = value; }
        }
        private int CodigoProveedor;

        public int CodigoProveedor1
        {
            get { return CodigoProveedor; }
            set { CodigoProveedor = value; }
        }
        private string Nombre;

        public string Nombre1
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        private string Direccion;

        public string Direccion1
        {
            get { return Direccion; }
            set { Direccion = value; }
        }
        private int Telefono;

        public int Telefono1
        {
            get { return Telefono; }
            set { Telefono = value; }
        }
        private Int64 RUC;

        public Int64 RUC1
        {
            get { return RUC; }
            set { RUC = value; }
        }
        private string Correo;

        public string Correo1
        {
            get { return Correo; }
            set { Correo = value; }
        }
        private string Responsable;

        public string Responsable1
        {
            get { return Responsable; }
            set { Responsable = value; }
        }
        private Boolean Estado;

        public Boolean Estado1
        {
            get { return Estado; }
            set { Estado = value; }
        }

        public E_Proveedor()
        {
            IdProveedor = 0;
            CodigoProveedor = 0;
            Nombre = "";
            Direccion = "";
            Telefono = 0;
            RUC = 0;
            Correo = "";
            Responsable = "";
            Estado = true;
        }
    }
}
