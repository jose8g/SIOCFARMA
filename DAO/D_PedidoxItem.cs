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
    public class D_PedidoxItem
    {
        SqlConnection conexion;
        private SqlDataAdapter mDa;
        private DataSet mdd;
        private SqlCommand mCm;

        public D_PedidoxItem()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable ListarItemsxPedido(int IdPedido)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_MostrarItemsxPedido", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                mdd = new DataSet();
                mDa.Fill(mdd);
                return mdd.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarPedidoxItem(E_PedidoxItem objE_PedI)
        {
            SqlCommand unCommand = new SqlCommand("SP_EliminarPedidosxItem", conexion);
            unCommand.CommandType = CommandType.StoredProcedure;

            unCommand.Parameters.AddWithValue("@IdPedido", objE_PedI.IdPedido1);
            unCommand.Parameters.AddWithValue("@IdItem", objE_PedI.IdItem1);
            conexion.Open();
            unCommand.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
