using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Item
    {
        private int idItem;
        public int IdItem
        {
            get { return IdItem; }
            set { IdItem = value; }
        }


        private string nombre;
        public string Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }


        private decimal precioVenta;
        public decimal PrecioVenta
        {
            get { return PrecioVenta; }
            set { PrecioVenta = value; }
        }


        private char estado;
        public char Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }


        private int idTipo;
        public int IdTipo
        {
            get { return IdTipo; }
            set { IdTipo = value; }
        }


        private int idMarca;
        public int IdMarca
        {
            get { return IdMarca; }
            set { IdMarca = value; }
        }


    }
}
