using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRinku.Model
{
    /// <summary>
    /// /Objeto Catalogo con los campos necesarios para formatear la información recibida en DataSet
    /// </summary>
    public class Catalogo
    {
        public int id { get; set; }
        public string  Descripcion { get; set; }
    }
}
