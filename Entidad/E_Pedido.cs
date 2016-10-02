using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Pedido
    {
        private int idPedido;
        public int IdPedido
        {
            get { return IdPedido; }
            set { IdPedido = value; }
        }


        private int numeroPedido;
        public int NumeroPedido
        {
            get { return NumeroPedido; }
            set { NumeroPedido = value; }
        }


        private char estado;
        public int Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }


    }
}
