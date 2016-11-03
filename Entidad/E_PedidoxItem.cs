using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_PedidoxItem
    {
        private int IdPedido;

        public int IdPedido1
        {
            get { return IdPedido; }
            set { IdPedido = value; }
        }
        private int IdProveedor;

        public int IdProveedor1
        {
            get { return IdProveedor; }
            set { IdProveedor = value; }
        }
        private int IdLote;

        public int IdLote1
        {
            get { return IdLote; }
            set { IdLote = value; }
        }
        private int IdItem;

        public int IdItem1
        {
            get { return IdItem; }
            set { IdItem = value; }
        }
        private int Cantidad;

        public int Cantidad1
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public E_PedidoxItem()
        {
            IdPedido = 0;
            IdProveedor = 0;
            IdLote = 0;
            IdItem = 0;
            Cantidad = 0;
        }
    }
}
