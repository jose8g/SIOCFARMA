﻿using System;
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
                return "Data Source=EDGAR-PC\\MSSQLSERVER1;Initial Catalog=BD_SIOCFARMA;Integrated Security=True";
            }
        }
    }
}
