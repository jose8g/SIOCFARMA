﻿using System;
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
    public class DAO_Compras
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection con = new SqlConnection(ConexionBD.CadenaConexion);
        public DataTable ConsultarCompras()
        {
            try
            {
                //mDa = new SqlDataAdapter("sp_lstConsultar_Categoria", con);
                mDa = new SqlDataAdapter("sp_listConsultarCompras", con);
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


        public DataTable getCompras()
        {
            try
            {
                //mDa = new SqlDataAdapter("sp_lstConsultar_Categoria", con);
                mDa = new SqlDataAdapter("sp_getCompras", con);
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

        public DataTable GetProductosByCompra(int idCompra)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_listProductosByCompra", con);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdCompra", idCompra);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataTable ItemxCompras(int idCompra)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_ItemxCompras", con);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdCompras", idCompra);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataTable GetCotizacionesCreadas()
        {
            mDa = new SqlDataAdapter("sp_listGetPedidosCotizados", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable GetProductosByPedido(int idPedido)
        {
            mDa = new SqlDataAdapter("sp_listProductosByPedido", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", idPedido);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public void ActualizarStockxMovimiento(String idCompra, int idItem, int cantidad)
        {
            mDa = new SqlDataAdapter("SP_ActualizarStockxMovimiento", con);
            mDa.SelectCommand.Parameters.AddWithValue("@IdCompra" , idCompra);
            mDa.SelectCommand.Parameters.AddWithValue("@IdItem"   , idItem);
            mDa.SelectCommand.Parameters.AddWithValue("@Cantidad" , cantidad);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
        }
        
        public DataTable InsertCompra(String idCompra, int idPedido, int idProveedor, int idItem, int cantidad)
        {
            mDa = new SqlDataAdapter("sp_insertCompra", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdCompra"    , idCompra);
            mDa.SelectCommand.Parameters.AddWithValue("@IdPedido"    , idPedido);
            mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor" , idProveedor);
            mDa.SelectCommand.Parameters.AddWithValue("@IdItem"      , idItem);
            mDa.SelectCommand.Parameters.AddWithValue("@Cantidad"    , cantidad);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable GetPreciosByItemCotizacion(int idItem, int idPedido){
            mDa = new SqlDataAdapter("sp_listPreciosCotizacionesByItem", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdItem"   , idItem);
            mDa.SelectCommand.Parameters.AddWithValue("@IdPedido" , idPedido);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
        
        public DataTable GetProveedoresPedido(int idPedido)
        {
            mDa = new SqlDataAdapter("sp_listProveedoresByPedido", con);
            mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", idPedido);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
        public DataTable DeleteItemCompra(int idCompra,int idItem)
        {
            mDa = new SqlDataAdapter("sp_deleteItemCompra", con);
            mDa.SelectCommand.Parameters.AddWithValue("@IdCompra" , idCompra);
            mDa.SelectCommand.Parameters.AddWithValue("@IdItem"   , idItem);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
        public DataTable UpdateItemByCompra(String idCompra, int idItem,int cantidad)
        {
            mDa = new SqlDataAdapter("sp_updateCantItemCompra", con);
            mDa.SelectCommand.Parameters.AddWithValue("@IdCompra" , idCompra);
            mDa.SelectCommand.Parameters.AddWithValue("@IdItem"   , idItem);
            mDa.SelectCommand.Parameters.AddWithValue("@Cantidad" , cantidad);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
        public DataTable VerifyIfCompraExists(String idCompra)
        {
            mDa = new SqlDataAdapter("sp_selectCompraExists", con);
            mDa.SelectCommand.Parameters.AddWithValue("@IdCompra" , idCompra);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
        public DataTable FinalizarCompra(String idCompra)
        {
            mDa = new SqlDataAdapter("sp_changeEstadoByCompra", con);
            mDa.SelectCommand.Parameters.AddWithValue("@IdCompra", idCompra);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
        public DataTable GetDataCompra(String idCompra)
        {
            mDa = new SqlDataAdapter("sp_getDataByCompra", con);
            mDa.SelectCommand.Parameters.AddWithValue("@IdCompra", idCompra);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable CompareIfExistsProductoCotizado(int idPedido, int idProveedor, int idItem)
        {
            mDa = new SqlDataAdapter("sp_validateItemCotizado", con);
            mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", idPedido);
            mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", idProveedor);
            mDa.SelectCommand.Parameters.AddWithValue("@IdItem", idItem);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
    }
}

