using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Venta
    {
        private string IdVenta;

        public string IdVenta1
        {
            get { return IdVenta1; }
            set { IdVenta1 = value; }
        }
        private string FechaRealizacion;

        public string FechaRealizacion1
        {
            get { return FechaRealizacion1; }
            set { FechaRealizacion1 = value; }
        }
        private string Observacion;

        public string Observacion1
        {
            get { return Observacion1; }
            set { Observacion1 = value; }
        }
        private string Estado;

        public string Estado1
        {
            get { return Estado1; }
            set { Estado1 = value; }
        }
        private string IdVendedor;

        public string IdVendedor1
        {
            get { return IdVendedor1; }
            set { IdVendedor1 = value; }
        }
        private string IdCliente;

        public string IdCliente1
        {
            get { return IdCliente1; }
            set { IdCliente1 = value; }
        }
        public E_Venta()
        {
            IdCliente1 = "";
            FechaRealizacion1 = "";
            Observacion1 = "";
            Estado1 = "";
            IdVendedor1 = "";
            IdCliente1 = "";

        }
        public E_Venta(string IdVentav, string FechaRealizacionv, string Observacionv, string Estadov, string IdVendedorv, string IdClientev)
        {
            IdVenta1 = IdVentav;
            FechaRealizacion1 = FechaRealizacionv;
            Observacion1 = Observacionv;
            Estado1 = Estadov;
            IdVendedor1 = IdVendedorv;
            IdCliente1 = IdClientev;

        }

    }
}
