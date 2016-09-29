using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidad;

namespace DAO
{
    class E_Venta
    {
        SqlConnection conexion;
        public E_Venta()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void Insert_E_Venta(string idventa,string fecharealizacion,string observacion,string estado,string idvendedor,string idcliente)
        {
            string Insertar = "INSERT E_Venta(IdV,FechaRealizacion,Observacion,Estado,IdVendedor,IdCliente) VALUES('" + idventa + "','" + fecharealizacion + "','" + observacion + "','" + estado + "','" + idvendedor + "','" + idcliente + "')";

            SqlCommand unComando = new SqlCommand(Insertar, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
