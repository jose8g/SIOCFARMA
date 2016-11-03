using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Lote
    {
        private int IdLote;

        public int IdLote1
        {
            get { return IdLote; }
            set { IdLote = value; }
        }
        private int Cantidad;

        public int Cantidad1
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        private string Medida;

        public string Medida1
        {
            get { return Medida; }
            set { Medida = value; }
        }
        private Boolean Estado;

        public Boolean Estado1
        {
            get { return Estado; }
            set { Estado = value; }
        }

        public E_Lote()
        {
            IdLote = 0;
            Cantidad = 0;
            Medida = "";
            Estado = false;
        }
    }
}
