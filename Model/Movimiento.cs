using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRinku.Model
{
    public class Movimiento
    {
        public long idMovimiento { get; set; }

        public long idEmpleado { get; set; }

        public int idRol { get; set; }

        public string  DescRol { get; set; }

        public string  Anio { get; set; }
        public int  idMes { get; set; }

        public string  DescMes { get; set; }


        public int CantEntrega { get; set; }
    }
}
