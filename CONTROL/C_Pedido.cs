using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidad;
using DAO;
namespace CONTROL
{
    public class C_Pedido
    {
        Entidad.E_Pedido objEPedido = new E_Pedido();
        DAO.DAO_Pedido objDPedido = new DAO.DAO_Pedido();
        public DataTable consultarPedido()
        {
            try
            {
                return objDPedido.consultarPedidoPendiente();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}