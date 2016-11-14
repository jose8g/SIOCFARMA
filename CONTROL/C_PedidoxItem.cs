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

        public DataTable ListarItemsxPedido(int IdPedido, int IdProveedor)
        {
            try
            {
                return objD_PedxIt.ListarItemsxPedido(IdPedido, IdProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
