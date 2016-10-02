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
    public class E_Venta
    {
        SqlConnection conexion;
        public E_Venta()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        //string Insertar = ";

        public void registrar_venta(string idventa, string fecharealizacion, string observacion, string estado, string idvendedor, string idcliente)
        {
            SqlCommand comando = new SqlCommand("sp_registrar_venta", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdVenta", idventa);
            comando.Parameters.AddWithValue("@FechaRealizacion", fecharealizacion);
            comando.Parameters.AddWithValue("@Observacion", observacion);
            comando.Parameters.AddWithValue("@Estado", estado);
            comando.Parameters.AddWithValue("@IdVendedor", idvendedor);
            comando.Parameters.AddWithValue("@IdCliente", idcliente);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
