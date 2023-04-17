using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRinku.Model
{
    public class Empleado
    {
        public long idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApePat { get; set; }
        public string ApeMat { get; set; }
        public int idRol { get; set; }

        public DateTime FechaAlta {get; set;}
        public string DescRol { get; set; }
        public bool Activo { get; set; }

    }
}
