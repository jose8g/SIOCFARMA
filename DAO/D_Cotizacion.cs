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
    public class D_Cotizacion
    {
        SqlConnection conexion;
        private SqlDataAdapter mDa;
        private DataSet mdd;
        private SqlCommand mCm;

        public D_Cotizacion()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertarCotizacion(E_Cotizacion objE_Cot)
        {
            SqlCommand unCommand = new SqlCommand("SP_InsertarCotizacion", conexion);
            unCommand.CommandType = CommandType.StoredProcedure;

            unCommand.Parameters.AddWithValue("@PreTotal", objE_Cot.PreTotal1);
            unCommand.Parameters.AddWithValue("@Descuento", objE_Cot.Descuento1);
            unCommand.Parameters.AddWithValue("@Total", objE_Cot.Total1);
            unCommand.Parameters.AddWithValue("@NombreCotizacion", objE_Cot.NombreCotizacion1);
            conexion.Open();
            unCommand.ExecuteNonQuery();

            conexion.Close();
        }

        public DataTable TotalCotizar()
        {
            mDa = new SqlDataAdapter("SP_TotalCotizar", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mdd = new DataSet();
            mDa.Fill(mdd);
            return mdd.Tables[0];
        }
    }
}
