using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidad;

namespace CONTROL
{
    public class C_PedidoxCotizacion
    {
        D_PedidoxCotizacion objD_PedC;

        public C_PedidoxCotizacion()
        {
            objD_PedC = new D_PedidoxCotizacion();
        }

        public void insertarPedidoxCotizacion(E_PedidoxCotizacion objE_PedC)
        {
            objD_PedC.InsertarPedidoxCotizacion(objE_PedC);
        }

        public void actualizarPedidoxCotizacion(E_PedidoxCotizacion objE_PedC)
        {
            objD_PedC.actualizarPedidoxCotizacion(objE_PedC);
        }

        public DataTable BuscarExistente(int IdPedido, int IdProveedor, int IdItem)
        {
            try
            {
                return objD_PedC.BuscarExistente(IdPedido, IdProveedor, IdItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable MostrarPedidoxCotizacion(int IdPedido, int IdProveedor)
        {
            try
            {
                return objD_PedC.MostrarPedidoxCotizacion(IdPedido, IdProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
