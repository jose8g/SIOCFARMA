﻿using System;
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
        private double PrecioCan; 

        public double PrecioCan1
        {
            get { return PrecioCan; }
            set { PrecioCan = value; }
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
        private int IdPedido;

        public int IdPedido1
        {
            get { return IdPedido; }
            set { IdPedido = value; }
        }

        public E_Cotizacion()
        {
            IdCotizacion = 0;
            NumCotizacion = 0;
            PrecioCan = 0.0;
            Total = 0.0;
            Estado = false;
            IdPedido = 0;
        }
    }
}