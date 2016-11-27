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
    public class DAO_Item
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;

        //Conecta la  BD
        public DAO_Item()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        //
        public void insertarItem(string Nombre, string PrecioVenta, string Estado, string IdTipo, string IdMarca)
        {
            SqlCommand comando = new SqlCommand("SP_REGISTRAR_ITEM_Marca_Tipo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@PrecioVenta", PrecioVenta);
            comando.Parameters.AddWithValue("@Estado", Estado);
            comando.Parameters.AddWithValue("@IdTipo", IdTipo);
            comando.Parameters.AddWithValue("@IdMarca", IdMarca);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable ConsultarItemcreado(string Nombre)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_Consultaritemxnombre", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMarcasCreadas()
        {

            mDa = new SqlDataAdapter("sp_getMarcas1", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }

        public DataTable getTipoItemCreadas()
        {

            mDa = new SqlDataAdapter("sp_getTipoItem", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }

        public DataTable getComposicionCreadas()
        {

            mDa = new SqlDataAdapter("sp_getComposicion", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }

        public DataTable getItemxStock()
        {

            mDa = new SqlDataAdapter("sp_getItemxStock", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }

        public DataTable getCopyPedidoxItem()
        {

            mDa = new SqlDataAdapter("sp_getCopyItemxStock", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }

        public DataTable getItemsByNombre(string Nombre)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getItemByNombreByStock", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable insertarPedidoxItem(string IdPedido, string IdItem, decimal precio)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_registrar_pedidoxItem", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                mDa.SelectCommand.Parameters.AddWithValue("@IdItem", IdItem);
                mDa.SelectCommand.Parameters.AddWithValue("@Precio", precio);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertarPedido()
        {
            SqlCommand comando = new SqlCommand("sp_registrar_pedido", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@IdPedido", SqlDbType.Int);
            comando.Parameters["@IdPedido"].Direction = ParameterDirection.Output;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();

            return Convert.ToInt32(comando.Parameters["@IdPedido"].Value);
        }
    }
}
