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
    public class DAO_Marca
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;

        //Conecta la  BD
        public DAO_Marca()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        //*creo las variables necesarias para el insert pdt:que el id se autogenerable para que no s einserte,luego en ves de meter 
        //el coidgo que seleccione y en tu procedure lo guardas  en una variable la cual compara con el id de la tabla  ala qque pertenece
        //asi ya no me tes codigo sin listas xD

        //
        public void insertarMarca(string NombreM, string Descripcion)
        {
            SqlCommand comando = new SqlCommand("SP_InsertarMarca", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", NombreM);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable GetMarcasCreadas()
        {
            mDa = new SqlDataAdapter("sp_getMarcas", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];
        }
    }
}
