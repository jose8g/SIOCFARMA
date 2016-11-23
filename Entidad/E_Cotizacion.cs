using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Cotizacion
    {
        private int IdCotizacion;

        public int IdCotizacion1
        {
            get { return IdCotizacion; }
            set { IdCotizacion = value; }
        }
        private int NumCotizacion;

        public int NumCotizacion1
        {
            get { return NumCotizacion; }
            set { NumCotizacion = value; }
        }

        private double PreTotal;

        public double PreTotal1
        {
            get { return PreTotal; }
            set { PreTotal = value; }
        }

        private double Descuento;

        public double Descuento1
        {
            get { return Descuento; }
            set { Descuento = value; }
        }

        private double Total;

        public double Total1
        {
            get { return Total; }
            set { Total = value; }
        }

        private Boolean Estado;

        public Boolean Estado1
        {
            get { return Estado; }
            set { Estado = value; }
        }

        private string NombreCotizacion;

        public string NombreCotizacion1
        {
            get { return NombreCotizacion; }
            set { NombreCotizacion = value; }
        }
        public E_Cotizacion()
        {
            PreTotal = 0.0;
            Descuento = 0.0;
            Total = 0.0;
            NombreCotizacion = "";
        }
    }
}
