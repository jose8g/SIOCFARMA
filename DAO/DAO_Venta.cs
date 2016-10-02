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

        public void registrar_venta(string idventa, string fecharealizacion, string observacion, string estado, string idvendedor, string idcliente)
        {
            SqlCommand comando = new SqlCommand("sp_registrar_venta", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdVenta", idventa);
            comando.Parameters.AddWithValue("@FechaRealizacion", fecharealizacion);
            comando.Parameters.AddWithValue("@Observacion", observacion);
            comando.Parameters.AddWithValue("@Estado", estado);
            comando.Parameters.AddWithValue("@IdVendedor", idvendedor);
            comando.Parameters.AddWithValue("@IdCliente", idcliente);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
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
    }
}