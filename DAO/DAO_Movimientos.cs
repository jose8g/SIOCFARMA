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

        public DataTable ActualizarStockxAjusteNegativo(int Cantidad, int IdItem)
        {
            mDa = new SqlDataAdapter("SP_ActualizarStockxAjusteNegativo", conexion);
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

        public void InsertarMoviminento(int CantidadMovida, string Responsable, string Observacion, string ResAutorizacion, int TipoMov, int idItem)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarMoviminento", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            mDa.SelectCommand.Parameters.AddWithValue("@CantidadMovida", CantidadMovida);
            mDa.SelectCommand.Parameters.AddWithValue("@Responsable", Responsable);
            mDa.SelectCommand.Parameters.AddWithValue("@Observacion", Observacion);
            mDa.SelectCommand.Parameters.AddWithValue("@ResAutorizacion", ResAutorizacion);
            mDa.SelectCommand.Parameters.AddWithValue("@TipoMov", TipoMov);
            mDa.SelectCommand.Parameters.AddWithValue("@idItem", idItem);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void InsertarMoviminentoneg(int CantidadMovida, string Responsable, string Observacion, int TipoMov, int idItem)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarMoviminentoneg", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            mDa.SelectCommand.Parameters.AddWithValue("@CantidadMovida", CantidadMovida);
            mDa.SelectCommand.Parameters.AddWithValue("@Responsable", Responsable);
            mDa.SelectCommand.Parameters.AddWithValue("@Observacion", Observacion);
            mDa.SelectCommand.Parameters.AddWithValue("@TipoMov", TipoMov);
            mDa.SelectCommand.Parameters.AddWithValue("@idItem", idItem);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
