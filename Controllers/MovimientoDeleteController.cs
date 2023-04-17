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
    public class MovimientoDeleteController : ControllerBase
    {
       
        
        
            db dbop = new db();
        /// <summary>
        /// /Elimina un movimiento por el idMovimiento 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
            [HttpGet("{id}")]
            public string DeleteMovimientoById(long id)
            {

                string mensaje = dbop.EliminaMovimiento(id);




                return mensaje;
            }

       
    }
}
