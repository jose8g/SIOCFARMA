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
    public class DAO_Almacen
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection conexion;
        public DAO_Almacen()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable getAlmacenes()
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getAlmacenes", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void registrarAlmacen(String direccion, String responsable, int capacidad)
        {
            SqlCommand comando = new SqlCommand("sp_insertar_almacen", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Direccion", direccion);
            comando.Parameters.AddWithValue("@Responsable", responsable);
            comando.Parameters.AddWithValue("@Capacidad", capacidad);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void editarDatosAlmacen(int idAlmacen, String direccion, String responsable, int capacidad)
        {
            SqlCommand comando = new SqlCommand("sp_editar_almacen", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdAlmacen", idAlmacen);
            comando.Parameters.AddWithValue("@Direccion", direccion);
            comando.Parameters.AddWithValue("@Responsable", responsable);
            comando.Parameters.AddWithValue("@Capacidad", capacidad);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable getDetalleAlmacen(int IdAlmacen)
        {
            try
            {
                mDa = new SqlDataAdapter("sp_getDetalleAlmacen", conexion);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDa.SelectCommand.Parameters.AddWithValue("@IdAlmacen", IdAlmacen);
                mDs = new DataSet();
                mDa.Fill(mDs);
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarAlmacen(int idAlmacen)
        {
            SqlCommand comando = new SqlCommand("sp_deleteAlmacen", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdAlmacen", idAlmacen);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
