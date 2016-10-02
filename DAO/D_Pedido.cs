using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidad;

namespace DAO
{
    public class D_Pedido
    {
        SqlConnection conexion;
        private SqlDataAdapter mDa;
        private DataSet mdd;
        private SqlCommand mCm;
        public D_Pedido()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable ListarPedidos()
        {
            try
            {
                mDa = new SqlDataAdapter("SP_ListarPedidos", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdd = new DataSet();
                mDa.Fill(mdd);
                return mdd.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
