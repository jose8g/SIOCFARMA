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
    public class DAO_Cliente
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;

        public DAO_Cliente()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable deleteCliente(int IdCliente)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_delete_Cliente", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdCliente", IdCliente);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RegistrarCliente(string Nombre, string Direccion, int Telefono, string Correo, int Dni, string Empresa)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_InsertarCliente", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre);
                mDa.SelectCommand.Parameters.AddWithValue("@Direccion", Direccion);
                mDa.SelectCommand.Parameters.AddWithValue("@Telefono", Telefono);
                mDa.SelectCommand.Parameters.AddWithValue("@Correo", Correo);
                mDa.SelectCommand.Parameters.AddWithValue("@Dni", Dni);
                mDa.SelectCommand.Parameters.AddWithValue("@Empresa", Empresa);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
