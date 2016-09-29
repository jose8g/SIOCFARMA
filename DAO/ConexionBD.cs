using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                return "data source=(local);initial catalog=BD_SIOCFARMA; integrated security=SSPI; ";
            }
        }
    }
}
