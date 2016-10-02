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

        public DataTable GetCotizacionesCreadas()
        {
            mDa = new SqlDataAdapter("sp_listGetCotizacionesCreadas", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable GetProductosByCotizacion(int idCotizacion)
        {
            mDa = new SqlDataAdapter("sp_listProductosByCotizacion", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable InsertCompraByCotizacion(int idCotizacion){
            mDa = new SqlDataAdapter("sp_insertCompraByCotizacion", con);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
    }
}

