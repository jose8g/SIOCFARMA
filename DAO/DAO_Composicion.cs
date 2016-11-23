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
    public class DAO_Composicion
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;
      
        //Conecta la  BD
        public DAO_Composicion()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertarComposicion(string NombreC, string Descripcion)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarComposicion", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", NombreC);
            comando.Parameters.AddWithValue("@Restricciones", Descripcion);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable ConsultarCompSeleccionar(string IdComponente)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_ConComposicion", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdComponente", IdComponente);
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
