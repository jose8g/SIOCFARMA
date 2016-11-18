using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidad;

namespace CONTROL
{
    public class C_Cotizacion
    {
        D_Cotizacion objD_Cot;

        public C_Cotizacion()
        {
            objD_Cot = new D_Cotizacion();
        }

        public void insertarCotizacion(E_Cotizacion objE_Cot)
        {
            objD_Cot.insertarCotizacion(objE_Cot);
        }
    }
}
