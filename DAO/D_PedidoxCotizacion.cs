﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidad;

namespace DAO
{
    public class D_PedidoxCotizacion
    {
        SqlConnection conexion;
        private SqlDataAdapter mDa;
        private DataSet mdd;
        private SqlCommand mCm;

        public D_PedidoxCotizacion()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void InsertarPedidoxCotizacion(E_PedidoxCotizacion objE_PedC)
        {
            try
            {
                mCm = new SqlCommand("SP_InsertarPedidoxCotizacion", conexion);
                mCm.CommandType = CommandType.StoredProcedure;

                mCm.Parameters.AddWithValue("@IdPedido", objE_PedC.IdPedido1);
                mCm.Parameters.AddWithValue("@IdProveedor", objE_PedC.IdProveedor1);
                mCm.Parameters.AddWithValue("@IdLote", objE_PedC.IdLote1);
                mCm.Parameters.AddWithValue("@IdItem", objE_PedC.IdItem1);
                mCm.Parameters.AddWithValue("@Cantidad", objE_PedC.Cantidad1);
                mCm.Parameters.AddWithValue("@PrecioUnitario", objE_PedC.PrecioUnitario1);
                conexion.Open();
                mCm.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void actualizarPedidoxCotizacion(E_PedidoxCotizacion objE_PedC)
        {
            try
            {
                mCm = new SqlCommand("SP_ActualizarPedidoxCotizacion", conexion);
                mCm.CommandType = CommandType.StoredProcedure;

                mCm.Parameters.AddWithValue("@IdPedido", objE_PedC.IdPedido1);
                mCm.Parameters.AddWithValue("@IdProveedor", objE_PedC.IdProveedor1);
                mCm.Parameters.AddWithValue("@IdLote", objE_PedC.IdLote1);
                mCm.Parameters.AddWithValue("@IdItem", objE_PedC.IdItem1);
                mCm.Parameters.AddWithValue("@Cantidad", objE_PedC.Cantidad1);
                mCm.Parameters.AddWithValue("@PrecioUnitario", objE_PedC.PrecioUnitario1);
                conexion.Open();
                mCm.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable BuscarExistente(int IdPedido, int IdProveedor, int IdItem)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_BuscarExistente", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);
                mDa.SelectCommand.Parameters.AddWithValue("@IdItem", IdItem);
                mdd = new DataSet();
                mDa.Fill(mdd);
                return mdd.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable MostrarPedidoxCotizacion(int IdPedido, int IdProveedor, int IdItem)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_MostrarPedidosxCotizacion", conexion);
                mDa.SelectCommand.Parameters.AddWithValue("@IdPedido", IdPedido);
                mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);
                mDa.SelectCommand.Parameters.AddWithValue("@IdItem", IdItem);
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
