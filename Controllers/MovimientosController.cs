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
    public class MovimientosController : ControllerBase
    {
        db dbop = new db();

        /// <summary>
        /// Consulta un Movimiento por el iDMovimiento para su edición
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Movimiento Movimiento_By_id(int id)
        {
            //int mes = 1;
            Movimiento MovimientoObj = new Movimiento();
            DataSet ds = dbop.Movimiento_ById(id);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {


                MovimientoObj = (new Movimiento
                {
                    idMovimiento = Convert.ToInt64(dr["idMovimiento"]),
                    idEmpleado = Convert.ToInt64(dr["idEmpleado"]),
                    idRol = Convert.ToInt32(dr["idRol"]),
                    idMes = Convert.ToInt32(dr["idMes"]),
                    CantEntrega = Convert.ToInt32(dr["CantEntregas"]),
                    Anio = dr["Anio"].ToString()

                });
            }


            return MovimientoObj;
        }


    }
}
