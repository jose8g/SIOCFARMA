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
    public class DAO_Item
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;

        //Conecta la  BD
        public DAO_Item()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        //*creo las variables necesarias para el insert pdt:que el id se autogenerable para que no s einserte,luego en ves de meter 
        //el coidgo que seleccione y en tu procedure lo guardas  en una variable la cual compara con el id de la tabla  ala qque pertenece
        //asi ya no me tes codigo sin listas xD

        //
        public void insertarItem(string Nombre, string PrecioVenta, string Estado, string IdTipo, string IdMarca)
        {
            SqlCommand comando = new SqlCommand("SP_REGISTRAR_ITEM_Marca_Tipo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@PrecioVenta", PrecioVenta);
            comando.Parameters.AddWithValue("@Estado", Estado);
            comando.Parameters.AddWithValue("@NombreT", IdTipo);
            comando.Parameters.AddWithValue("@NombreM", IdMarca);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable getItemsByNombre(string Nombre)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_obtenerItemPorNombre", conexion);
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
        public DataTable ConsultarItemcreado(string Nombre)
        {
            try
            {
                mDa = new SqlDataAdapter("SP_Consultaritemxnombre", conexion);
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

        public DataTable getMarcasCreadas()
        {

            mDa = new SqlDataAdapter("sp_getMarcas", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }

        public DataTable getTipoItemCreadas()
        {

            mDa = new SqlDataAdapter("sp_getTipoItem", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }

        public DataTable getComposicionCreadas()
        {

            mDa = new SqlDataAdapter("sp_getComposicion", conexion);
            mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            mDs = new DataSet();
            mDa.Fill(mDs);
            return mDs.Tables[0];


        }
    }
}
