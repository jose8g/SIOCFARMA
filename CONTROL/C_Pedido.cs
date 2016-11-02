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
    public class C_Pedido
    {
        DAO_Pedido objD_Ped;

        public C_Pedido()
        {
            objD_Ped = new DAO_Pedido();
        }

        /*public DataTable ListarPedidos()
        {
            try
            {
                return objD_Ped.ListarPedidosxProveedor(IdProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}
