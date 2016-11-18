using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                //return "Data Source=EDGAR-PC\\MSSQLSERVER1;Initial Catalog=BD_SIOCFARMA;Integrated Security=True";
                //return "Data Source=LAPTOP-ARICDKF6\\SQLEXPRESS;Initial Catalog=BD_SIOCFARMA;Integrated Security=True";
                //return "Data Source=USER\\SQLEXPRESS;Initial Catalog=BD_SIOCFARMA;Integrated Security=True";
                //return "Data Source=WINDOWS-OSHK0B1;Initial Catalog=BD_SIOCFARMA;Integrated Security=True";
                return "Data Source=TOSHIBA\\SQLEXPRESS;Initial Catalog=BD_SIOCFARMA;Integrated Security=True";
            }
        }
    }
}
