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
    public class D_Proveedor
    {
        SqlConnection conexion;
        private SqlDataAdapter mDa;
        private DataSet mdd;
        private SqlCommand mCm;

        public D_Proveedor()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertarProveedor(E_Proveedor objE_Prov)
        {
            SqlCommand unCommand = new SqlCommand("SP_InsertarProveedor", conexion);
            unCommand.CommandType = CommandType.StoredProcedure;

            unCommand.Parameters.AddWithValue("@Nombre", objE_Prov.Nombre1);
            unCommand.Parameters.AddWithValue("@Direccion", objE_Prov.Direccion1);
            unCommand.Parameters.AddWithValue("@Telefono", objE_Prov.Telefono1);
            unCommand.Parameters.AddWithValue("@RUC", objE_Prov.RUC1);
            unCommand.Parameters.AddWithValue("@Correo", objE_Prov.Correo1);
            unCommand.Parameters.AddWithValue("@Responsable", objE_Prov.Responsable1);
            conexion.Open();
            unCommand.ExecuteNonQuery();

            conexion.Close();
        }

        public void actualizarProveedor(E_Proveedor objE_Prov)
        {
            try
            {
                mCm = new SqlCommand("SP_ActualizarProveedor", conexion);
                mCm.CommandType = CommandType.StoredProcedure;

                mCm.Parameters.AddWithValue("@IdProveedor",objE_Prov.IdProveedor1);
                mCm.Parameters.AddWithValue("@Nombre", objE_Prov.Nombre1);
                mCm.Parameters.AddWithValue("@Direccion", objE_Prov.Direccion1);
                mCm.Parameters.AddWithValue("@Telefono", objE_Prov.Telefono1);
                mCm.Parameters.AddWithValue("@RUC", objE_Prov.RUC1);
                mCm.Parameters.AddWithValue("@Correo", objE_Prov.Correo1);
                mCm.Parameters.AddWithValue("@Responsable", objE_Prov.Responsable1);
                mCm.Parameters.AddWithValue("@Estado", objE_Prov.Estado1);
                conexion.Open();
                mCm.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable eliminarProveedor(int IdProveedor)
        {
            mDa = new SqlDataAdapter("SP_EliminarProveedor", conexion);
            mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mdd = new DataSet();
            mDa.Fill(mdd);
            return mdd.Tables[0];
        }

        public DataTable MostrarProveedor()
        {
            try
            {
                mDa = new SqlDataAdapter("SP_MostrarProveedor", conexion);
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

        public DataTable BuscarProveedor(int IdUsuario)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_BuscarProveedor", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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
