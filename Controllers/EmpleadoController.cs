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

    public class EmpleadoController : ControllerBase
    {

        /// <summary>
        /// Controlador que recibe un objeto por metodo post y lo manda al modelo para guardarlos
        /// Este guarda o edita a un Empleado 
        /// </summary>
        db dbop = new db();
        [HttpPost]
        public string  Guarda([FromBody] Empleado Emp)
        {
            string msg = string.Empty;
            long idGenerado = 0;
            List<Empleado> lstEmpleado = new List<Empleado>();
            try
            {
                DataSet ds = dbop.EmpleadoCreate(Emp);
                    idGenerado = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());


                if (Emp.idEmpleado > 0)
                {
                    msg = "Empleado actualizado Correctamente";
                }
                else
                {
                    msg = "Empleado #" + idGenerado + " Guardado Correctamente";
                }
               


            }
            catch (Exception es)
            {
                msg = "Error el Guardar al empleado";
                throw;
            }


            return msg;


        }

        /// <summary>
        /// /Consulta a un empleado por IdEmpleado, esto para la edición
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Empleado Empleado_By_id(int id)
        {
            //int mes = 1;
            Empleado EmpleadoObj = new Empleado();
            DataSet ds = dbop.Empleado_ById(id);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {


                EmpleadoObj = (new Empleado
                {
                    idEmpleado = Convert.ToInt64(dr["idEmpleado"]),
                    idRol = Convert.ToInt32(dr["idRol"]),
                    Nombre = dr["Nombre"].ToString(),
                    ApePat = dr["ApePat"].ToString(),
                    ApeMat = dr["ApeMat"].ToString(),
                    DescRol = dr["DescRol"].ToString(),
                    FechaAlta = Convert.ToDateTime(dr["FechaAlta"].ToString())
               
                    





                });
            }


            return EmpleadoObj;
        }

    }
}
