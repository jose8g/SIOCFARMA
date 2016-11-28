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
    public class DAO_Venta
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;
        public DAO_Venta()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        //string Insertar = ";

        public int registrar_venta()
        {
            SqlCommand comando = new SqlCommand("sp_registrar_venta", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@IdVenta", SqlDbType.Int);
            comando.Parameters["@IdVenta"].Direction = ParameterDirection.Output;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();

            return Convert.ToInt32(comando.Parameters["@IdVenta"].Value);
        }

        public DataTable getItemsByNombre(string Nombre, int idMarca, int idTipo)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getItemByNombre", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre);
                mDa.SelectCommand.Parameters.AddWithValue("@IdMarca", idMarca);
                mDa.SelectCommand.Parameters.AddWithValue("@IdTipo", idTipo);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void addArrayVenta(string idItem)
        {
        }

        //public DataTable GetMarcasCreadas()
        //{
        //    ////mDa = new SqlDataAdapter("sp_getMarcas", conexion);
        //    ////mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    ////mDs = new DataSet();
        //    ////mDa.Fill(mDs);
        //    ////return mDs.Tables[0];
        //}

        //public DataTable GetTiposCreados()
        //{
        //    mDa = new SqlDataAdapter("sp_getTipos", conexion);
        //    mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    mDs = new DataSet();
        //    mDa.Fill(mDs);
        //    return mDs.Tables[0];
        //}

        public DataTable getItemsByMarca(int IdMarca)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getItemByMarca", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdMarca", IdMarca);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getItemsByTipo(int IdTipo)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getItemByTipo", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdTipo", IdTipo);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable registarItemXVenta(string IdVenta, string IdItem)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_registrar_ventaxitem", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdVenta", IdVenta);
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

        public int updateCantidad(int idVenta, int idAlmacen, int idItem, int cantidad)
        {
            SqlCommand comando = new SqlCommand("sp_editar_cantidadVenta", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdVenta", idVenta);
            comando.Parameters.AddWithValue("@IdAlmacen", idAlmacen);
            comando.Parameters.AddWithValue("@IdItem",   idItem);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            comando.Parameters.Add("@salida", SqlDbType.Int);
            comando.Parameters["@salida"].Direction = ParameterDirection.Output;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();

            return Convert.ToInt32(comando.Parameters["@salida"].Value);
        }

        public DataTable deleteItemxVenta(int IdVenta, int IdAlmacen, int IdItem)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_delete_VentaXItem", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdVenta", IdVenta);
                mDa.SelectCommand.Parameters.AddWithValue("@IdAlmacen", IdAlmacen);
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

        public DataTable getVentasPendientes()
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getVentasPendientes", conexion);
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
        public void deleteVenta(int idVenta, int IdAlmacen)
        {
            SqlCommand comando = new SqlCommand("sp_delete_Venta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdVenta", idVenta);
            comando.Parameters.AddWithValue("@IdAlmacen", IdAlmacen);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable getItemsByVenta(int IdVenta)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getItemsByVenta", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdVenta", IdVenta);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int finalizarVenta(int idVenta)
        {
            SqlCommand comando = new SqlCommand("sp_finalizarVenta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdVenta", idVenta);
            comando.Parameters.Add("@salida", SqlDbType.Int);
            comando.Parameters["@salida"].Direction = ParameterDirection.Output;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return Convert.ToInt32(comando.Parameters["@salida"].Value);
        }
        
        public DataTable getDetalleVenta(int IdVenta)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getDetalleVenta", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdVenta", IdVenta);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getItemsByVentaPDF(int IdVenta)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getItemsByVentaPDF", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdVenta", IdVenta);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int getAlmacenByVendedor(int IdVendedor)
        {
            SqlCommand comando = new SqlCommand("sp_getAlmacenByVendedor", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdVendedor", IdVendedor);
            comando.Parameters.Add("@salida", SqlDbType.Int);
            comando.Parameters["@salida"].Direction = ParameterDirection.Output;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();

            return Convert.ToInt32(comando.Parameters["@salida"].Value);
        }
    }
}