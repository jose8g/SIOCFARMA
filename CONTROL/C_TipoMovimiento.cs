using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using DAO;
using System.Data;

namespace CONTROL
{
    public class C_TipoMovimiento
    {
        DAO_TipoMovimiento dao = new DAO_TipoMovimiento();



        public DataTable getTipoMovimiento()
        {
            try
            {
                return dao.getTipoMovimiento();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
