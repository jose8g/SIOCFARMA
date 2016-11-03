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

            unCommand.Parameters.AddWithValue("@NumCotizacion", objE_Cot.NumCotizacion1);
            unCommand.Parameters.AddWithValue("@PrecioCan", objE_Cot.PrecioCan1);
            unCommand.Parameters.AddWithValue("@Total", objE_Cot.Total1);
            unCommand.Parameters.AddWithValue("@Estado", objE_Cot.Estado1);
            conexion.Open();
            unCommand.ExecuteNonQuery();

            conexion.Close();
        }


    }
}
