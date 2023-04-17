using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRinku.Model
{
    /// <summary>
    /// Objeto Variable con los campos necesarios para formatear la información recibida en DataSet sobre los datos variables de la nómina
    /// </summary>
    public class Variable
    {
        public string  DescVariable { get; set; }
        public decimal Porcentaje { get; set; }

    }
}
