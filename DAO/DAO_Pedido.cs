using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAO
{
    public class DAO_Pedido{

        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection con = new SqlConnection(ConexionBD.CadenaConexion);

        
        public DataTable ConsultarPedidosPendientes()
        {
            /*try
            {
                mDa = new SqlDataAdapter("sp_listConsultarPedidosPendientes", con);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDs = new DataSet();
                mDa.Fill(mDs);
                con.Close();
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;

            }*/
            return null;

        }

        public DataTable getItemxPedido()
        {
            try
            {
                mDa = new SqlDataAdapter("[sp_getItemxPedido]", con);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDs = new DataSet();
                mDa.Fill(mDs);
                con.Close();
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public void updateCantidadPedido(int idPedido, int idItem, int cantidad)
        {
            SqlCommand comando = new SqlCommand("sp_editar_cantidadPedido", con);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdPedido", idPedido);
            comando.Parameters.AddWithValue("@IdItem", idItem);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
        }

        public DataTable deleteItemxPedido(int IdPedido, int IdItem)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_delete_PedidoXItem", con);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                mDa.SelectCommand.Parameters.AddWithValue("@IdItem", IdItem);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarProveedorxPedido(int IdPedido, int IdProveedor)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarProveedorxPedido", con);
            comando.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
            mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
        }
    

        //public int finalizarPedido(int idPedido)
        //{
        //    SqlCommand comando = new SqlCommand("sp_finalizarPedido", con);
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.AddWithValue("@idPedido", idPedido);
        //    comando.Parameters.Add("@salida", SqlDbType.Int);
        //    comando.Parameters["@salida"].Direction = ParameterDirection.Output;
        //    con.Open();
        //    comando.ExecuteNonQuery();
        //    con.Close();
        //    return Convert.ToInt32(comando.Parameters["@salida"].Value);
        //}

        public DataTable getPedido()
        {

            mDa = new SqlDataAdapter("sp_getPedido", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable getProveedorxPedidos()
        {

            mDa = new SqlDataAdapter("sp_getProveedorxPedido", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            con.Open();
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable getIdPedido()
        {

            mDa = new SqlDataAdapter("sp_getIdPedido", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable getIdProveedor()
        {

            mDa = new SqlDataAdapter("sp_getIdProveedor", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable getItemsDePedido(int IdPedido)
        {
            mDa = new SqlDataAdapter("sp_getItemsDePedido", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable getAllProveedor(int IdProveedor)
        {
            mDa = new SqlDataAdapter("sp_getAllProveedor", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable deletePedido(int IdPedido)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_delete_Pedido", con);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable deleteProveedorxPedido(int IdPedido, int IdProveedor)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_DeleteProveedorxPedido", con);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);
                con.Open();
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
