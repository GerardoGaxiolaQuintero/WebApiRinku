using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRinku.Model;
using System.Data;

namespace WebApiRinku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoDeleteController : ControllerBase
    {
        db dbop = new db();
        [HttpGet("{id}")]
        public string  DeleteEmpleadoById(long  id)
        {

            string mensaje = dbop.EliminaEmpleado(id);

                  


            return mensaje;
        }

    }
}
