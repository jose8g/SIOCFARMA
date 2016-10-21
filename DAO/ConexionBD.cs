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
                return "Data Source=TOSHIBA\\SQLEXPRESS;Initial Catalog=BD_SIOCFARMA;Integrated Security=True";
            }
        }
    }
}
