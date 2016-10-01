using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_PedidoxLote
    {
        private int idPedidoxLote;
        public int IdPedidoxLote
        {
            get { return IdPedidoxLote; }
            set { IdPedidoxLote = value; }
        }

        private decimal cantidad;
        public decimal Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        private int idProveedorxItem;
        public int IdProveedorxItem
        {
            get { return IdProveedorxItem; }
            set { IdProveedorxItem = value; }
        }

        private int idProveedor;
        public int IdProveedor
        {
            get { return IdProveedor; }
            set { IdProveedor = value; }
        }

        private int idItem;
        public int IdItem
        {
            get { return IdItem; }
            set { IdItem = value; }
        }

        private int idPedido;
        public int IdPedido
        {
            get { return IdPedido; }
            set { IdPedido = value; }
        }


    }
}
