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
    public class RolesController : ControllerBase
    {
        db dbop = new db();

        /// <summary>
        /// /Consulta todos los roles activos del catalogo 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Catalogo> ListadoRoles()
        {
            List<Catalogo> lstRoles = new List<Catalogo>();
            DataSet ds = dbop.ObtenerRoles_Todos();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstRoles.Add(new Catalogo
                {
                    id = Convert.ToInt32(dr["id"].ToString()),
                    Descripcion = dr["Descripcion"].ToString(),
                   
                });
            }


            return lstRoles;
        }

       
        




    }
}
