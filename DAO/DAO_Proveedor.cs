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
    public class DAO_Proveedor
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;
      
        //Conecta la  BD
        public DAO_Proveedor()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable GetProveedoresCreadas()
        {
            mDa = new SqlDataAdapter("sp_getProveedor", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }

        public void insertarProveedores(string nombre, string Direccion, int Telefono, Int64 RUC, string Correo, string Responsable)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarProveedores", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            mDa.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
            mDa.SelectCommand.Parameters.AddWithValue("@Direccion", Direccion);
            mDa.SelectCommand.Parameters.AddWithValue("@Telefono", Telefono);
            mDa.SelectCommand.Parameters.AddWithValue("@RUC", RUC);
            mDa.SelectCommand.Parameters.AddWithValue("@Correo", Correo);
            mDa.SelectCommand.Parameters.AddWithValue("@Responsable", Responsable);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable ConsultarProvSeleccionar(int IdProveedor)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_ProProveedor", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdProveedor", IdProveedor);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getProveedorCreadas()
        {

            mDa = new SqlDataAdapter("sp_getProveedor", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }
    }
}
