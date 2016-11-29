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

        public DataTable ListarPedidosxProveedor(int IdProveedor)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_ListarPedidosxProveedor", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);
                mdd = new DataSet();
                mDa.Fill(mdd);
                return mdd.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void actualizarPedido(E_Pedido objE_Ped)
        {
            try
            {
                mCm = new SqlCommand("SP_ActualizarPedido", conexion);
                mCm.CommandType = CommandType.StoredProcedure;
                mCm.Parameters.AddWithValue("@IdPedido", objE_Ped.IdPedido1);
                conexion.Open();
                mCm.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
