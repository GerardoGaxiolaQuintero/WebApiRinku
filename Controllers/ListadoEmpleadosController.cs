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
    public class ListadoEmpleadosController : ControllerBase
    {
        //Consulta el listado de todos los empleados 
        db dbop = new db();
        [HttpGet]
        public List<Empleado> ListadoEmpleados()
        {
            List<Empleado> lstEmpleado = new List<Empleado>();
            DataSet ds = dbop.ObtenerEmpleados_Todos();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmpleado.Add(new Empleado
                {
                    idEmpleado = Convert.ToInt64(dr["idEmpleado"]),
                    Nombre = dr["Nombre"].ToString(),
                    ApePat = dr["ApePat"].ToString(),
                    ApeMat = dr["ApeMat"].ToString(),
                    DescRol = dr["DescRol"].ToString(),
                    idRol = Convert.ToInt32(dr["idRol"].ToString())
                });
            }


            return lstEmpleado;
        }

    }
}
