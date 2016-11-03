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
    public class C_Lote
    {
        D_Lote objD_Lo;

        public C_Lote()
        {
            objD_Lo = new D_Lote();
        }

        public DataTable ListarMedidas()
        {
            try
            {
                return objD_Lo.ListarMedidas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
