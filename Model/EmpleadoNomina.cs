using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRinku.Model
{/// <summary>
 /// Objeto EmpleadoNomina con los campos necesarios para formatear la información recibida en DataSet y llenados para el listado de la nómina
 /// </summary>
    public class EmpleadoNomina
    {
        public long idEmpleado { get; set; }

        public int  idRol { get; set; }


        public string  Nombre { get; set; }
        public string ApePat { get; set; }
        public string ApeMat { get; set; }

        public int CantEntregadas { get; set; }

        public int HorasTrabajadas { get; set; }

        public decimal PagoEntregas { get; set; }
        public decimal PagoBonos { get; set; }
        public decimal ISR  { get; set; }

        public decimal Vales { get; set; }

        public decimal SueldoFinal { get; set; }

    }
}
