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
    public class DAO_ProveedorxItem
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;
      
        //Conecta la  BD
        public DAO_ProveedorxItem()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertarProveedorxItem(int IdProveedor, int IdItem, string Estado)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarProveedoresnxitem", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdProveedor", IdProveedor);
            comando.Parameters.AddWithValue("@IdItem", IdItem);
            comando.Parameters.AddWithValue("@Estado", Estado);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable getProveedoresxItemCreadas(int iditem)
        {
            mDa = new SqlDataAdapter("SP_ConsultarProveedorxIte", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDa.SelectCommand.Parameters.AddWithValue("@idItem", iditem);
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
    }
}
