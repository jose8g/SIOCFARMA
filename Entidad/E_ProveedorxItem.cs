using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_ProveedorxItem
    {

        private int idProveedorxItem;
        public int IdProveedorxItem
        {
            get { return IdProveedorxItem; }
            set { IdProveedorxItem = value; }
        }

        private decimal precioUnitario;
        public int PrecioUnitario
        {
            get { return PrecioUnitario; }
            set { PrecioUnitario = value; }
        }

        private int cantidadRecibida;
        public int CantidadRecibida
        {
            get { return CantidadRecibida; }
            set { CantidadRecibida = value; }
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

    }
}
