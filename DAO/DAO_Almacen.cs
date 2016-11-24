using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidad;

namespace DAO
{
    public class DAO_Almacen
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;
        public DAO_Almacen()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable getAlmacenes()
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getAlmacenes", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
