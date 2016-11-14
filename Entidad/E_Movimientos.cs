using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Movimientos
    {

        private int idMovimiento;
        public int IdMovimiento
        {
            get { return idMovimiento; }
            set { idMovimiento = value; }
        }


        private DateTime registro;
        public DateTime Registro
        {
            get { return registro; }
            set { registro = value; }
        }


        private string cantidadMovida;
        public string CantidadMovida
        {
            get { return cantidadMovida; }
            set { cantidadMovida = value; }
        }

        private string responsable;
        public string Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }


        private string observacion;
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }


        private string resAutorizacion;
        public string ResAutorizacion
        {
            get { return resAutorizacion; }
            set { resAutorizacion = value; }
        }

        private char estado;
        public int Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }


        private int idAlmacenxItem;
        public int IdAlmacenxItem
        {
            get { return idAlmacenxItem; }
            set { idAlmacenxItem = value; }
        }


        private int idTipoMovimiento;
        public int IdTipoMovimiento
        {
            get { return idTipoMovimiento; }
            set { idTipoMovimiento = value; }
        }

        private int idAlmacen;
        public int IdAlmacen
        {
            get { return idAlmacen; }
            set { idAlmacen = value; }
        }


        private int idItem;
        public int IdItem
        {
            get { return idItem; }
            set { idItem = value; }
        }
    }
}
