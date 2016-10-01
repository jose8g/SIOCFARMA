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
    public class DAO_Pedido
    {
        SqlConnection conexion;
        public DAO_Pedido()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        //private SqlCommand mCommand;
        private SqlDataAdapter mDatAdapter;
        //private DataSet mDataSet;
        public DataTable consultarPedidoPendiente()
        {
            try
            {
                conexion.Open();
                mDatAdapter = new SqlDataAdapter("sp_consultarPedidoPendiente", conexion);
                mDatAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable daTablePedidoP = new DataTable();
                mDatAdapter.Fill(daTablePedidoP);
                conexion.Close();
                return daTablePedidoP;

                /*
                mDatAdapter = new SqlDataAdapter("sp_consultarPedidoPendiente", conexion);
                mDatAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDataSet = new DataSet();
                mDatAdapter.Fill(mDataSet);
                conexion.Close();
                return mDataSet.Tables[0];
                */

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
