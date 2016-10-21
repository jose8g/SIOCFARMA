using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAO
{
    public class DAO_Pedido{

        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection con = new SqlConnection(ConexionBD.CadenaConexion);

        
        public DataTable ConsultarPedidosPendientes()
        {
            /*try
            {
                mDa = new SqlDataAdapter("sp_listConsultarPedidosPendientes", con);
                mDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                mDs = new DataSet();
                mDa.Fill(mDs);
                con.Close();
                return mDs.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;

            }*/
            return null;

        }
        

    }
}
