using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Entidad;

namespace DAO
{
   public  class DAO_TipoMovimiento
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;

        //Conecta la  BD
        public DAO_TipoMovimiento()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable getTipoMovimiento()
        {

            mDa = new SqlDataAdapter("sp_getTipoMovimiento", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }
    }
}
