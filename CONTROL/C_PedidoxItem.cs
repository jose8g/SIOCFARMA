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
    public class C_PedidoxItem
    {
        D_PedidoxItem objD_PedxIt;
        public C_PedidoxItem()
        {
            objD_PedxIt = new D_PedidoxItem();
        }

        public DataTable ListarItemsxPedido(int IdPedido)
        {
            try
            {
                return objD_PedxIt.ListarItemsxPedido(IdPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarPedidoxItem(E_PedidoxItem objE_PedI)
        {
            objD_PedxIt.eliminarPedidoxItem(objE_PedI);
        }
    }
}
