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

        public DataTable getItemsByNombre(string Nombre)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getItemByNombre", conexion);
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

        public void addArrayVenta(string idItem)
        {
        }

        public DataTable GetMarcasCreadas()
        {
            mDa = new SqlDataAdapter("sp_getMarcas", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

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

        public void registarItemXVenta(string IdVenta, string IdItem)
        {
            SqlCommand comando = new SqlCommand("sp_registrar_ventaxitem", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdVenta", IdVenta);
            comando.Parameters.AddWithValue("@IdItem", IdItem);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}