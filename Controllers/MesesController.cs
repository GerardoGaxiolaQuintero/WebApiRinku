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
    public class MesesController : Controller
    {
        db dbop = new db();
        [HttpGet]
        public List<Catalogo> ListadoMeses()
        {
            List<Catalogo> lstMeses = new List<Catalogo>();
            DataSet ds = dbop.ObtenerMeses_Todos();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstMeses.Add(new Catalogo
                {
                    id = Convert.ToInt32(dr["id"].ToString()),
                    Descripcion = dr["Descripcion"].ToString(),

                });
            }


            return lstMeses;
        }
    }
}
