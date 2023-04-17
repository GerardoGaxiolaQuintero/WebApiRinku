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
    public class ListaMovimientosController : ControllerBase
    {
        db dbop = new db();
        [HttpGet("{id}")]
        public List<Movimiento> ListadoMovimientos(int id)
        {
           
            List<Movimiento> lstMovimientos = new List<Movimiento>();
            DataSet ds = dbop.ObtenerMovimientos_ByidEmpleado(id);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                

                lstMovimientos.Add(new Movimiento
                {
                    idMovimiento = Convert.ToInt64(dr["idMovimiento"]),
                    idEmpleado = Convert.ToInt64(dr["idEmpleado"]),
                   DescRol = dr["DescRolEmpleado"].ToString(),
                    DescMes = dr["DescMes"].ToString(),
                   CantEntrega = Convert.ToInt32(dr["CantEntregas"].ToString()),
                   Anio = dr["Anio"].ToString()





                });
            }


            return lstMovimientos;
        }

        [HttpPost]
        public string GuardaMovimiento([FromBody] Movimiento Mov)
        {
            string msg = string.Empty;
            long idGenerado = 0;
           
            try
            {
                DataSet ds = dbop.MovimientoCreate(Mov);
               
               // idGenerado = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());

                msg = "Movimiento Guardado Correctamente";


            }
            catch (Exception es)
            {
                msg = "Error al Guardar";
                throw;
            }


            return msg;


        }

    }
}
