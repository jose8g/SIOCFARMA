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
    public class DAO_Movimientos
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;
        public DAO_Movimientos()

        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable ActualizarStockxAjustePositivo(int Cantidad, int IdItem)
        {
            mDa = new SqlDataAdapter("SP_ActualizarStockxAjustePositivo", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@Cantidad", Cantidad);
            mDa.SelectCommand.Parameters.AddWithValue("@IdItem ", IdItem);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable VerStockxAjusteNegativo(int Cantidad, int IdItem)
        {
            mDa = new SqlDataAdapter("SP_VerStockxAjusteNegativo", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@Cantidad", Cantidad);
            mDa.SelectCommand.Parameters.AddWithValue("@IdItem ", IdItem);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable TrabajadorXUsuario(int idUsuario)
        {
            mDa = new SqlDataAdapter("sp_TrabajadorXUsuario", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable InsertarMoviminento(int CantidadMovida, string Responsable, string Observacion, string ResAutorizacion, int TipoMov, int idItem)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarMoviminento", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@CantidadMovida", CantidadMovida);
            comando.Parameters.AddWithValue("@Responsable", Responsable);
            comando.Parameters.AddWithValue("@Observacion", Observacion);
            comando.Parameters.AddWithValue("@ResAutorizacion", ResAutorizacion);
            comando.Parameters.AddWithValue("@TipoMov", TipoMov);
            comando.Parameters.AddWithValue("@idItem", idItem);
            conexion.Open();
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable InsertarMoviminentoneg(int CantidadMovida, string Responsable, string Observacion, int TipoMov, int idItem)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarMoviminentoneg", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@CantidadMovida", CantidadMovida);
            comando.Parameters.AddWithValue("@Responsable", Responsable);
            comando.Parameters.AddWithValue("@Observacion", Observacion);
            comando.Parameters.AddWithValue("@TipoMov", TipoMov);
            comando.Parameters.AddWithValue("@idItem", idItem);
            conexion.Open();
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
        public DataTable getAjustesNegativos()
        {
            mDa = new SqlDataAdapter("sp_getAjustesNegativos", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable ActualizarStockxAjusteNegativo(int IdMovimiento)
        {
            mDa = new SqlDataAdapter("SP_ActualizarStockxAjusteNegativo", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@IdMovimiento", IdMovimiento);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public DataTable getAprobarAjustesNegativos(int IdMovimiento)
        {
            SqlCommand comando = new SqlCommand("sp_getAprobarAjustesNegativos", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdMovimiento", IdMovimiento);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
    }
}
