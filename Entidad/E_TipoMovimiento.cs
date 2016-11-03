using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_TipoMovimiento
    {
        private int idTipoMovimiento;
        public int IdTipoMovimiento
        {
            get { return idTipoMovimiento; }
            set { idTipoMovimiento = value; }
        }


        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
