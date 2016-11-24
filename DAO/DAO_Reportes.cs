﻿using System;
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
    public class DAO_Reportes
    {
        private SqlCommand mCm;
        private SqlDataAdapter mDa;
        private DataSet mDs;
        SqlConnection con = new SqlConnection(ConexionBD.CadenaConexion);
        public DataTable ventasXVendedor()
        {
            try
            {
                //mDa = new SqlDataAdapter("sp_lstConsultar_Categoria", con);
                mDa = new SqlDataAdapter("sp_ventas_x_vendedor", con);
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
    }
}
