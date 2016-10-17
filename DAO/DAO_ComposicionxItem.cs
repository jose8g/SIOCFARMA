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
    public class DAO_ComposicionxItem
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;
      
        //Conecta la  BD
        public DAO_ComposicionxItem()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertarComposicionxItem(string medida, int cantidad,int idItem,int idcomposicion)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarComposicionxitem", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Medida", medida);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            comando.Parameters.AddWithValue("@IdItem", idItem);
            comando.Parameters.AddWithValue("@IdComposicion", idcomposicion);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable getComposicionesxItemCreadas(int iditem)
        {
            mDa = new SqlDataAdapter("SP_ConsultarComposicionxIte", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@idItem", iditem);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }


    }
}
