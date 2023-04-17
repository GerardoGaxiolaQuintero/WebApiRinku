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
    public class NominaController : ControllerBase
    {


        db dbop = new db();
        [HttpGet("{id}")]
        public List<EmpleadoNomina> ListadoNomina(string Anio,int id)
        {

            ///Consultamos las variables para cancular la nomina 

            List<Variable> Variables = new List<Variable>();

            DataSet dsVariables = dbop.ObtenerVariablesNomina(Anio);

            decimal JornadaLaboral = 0, DiaSemana = 0, PorceISR = 0, PorceVales = 0, SemanasMes = 0;

            

            foreach (DataRow drVariable in dsVariables.Tables[0].Rows)
            {
                string TituloVariante = drVariable["DescVariante"].ToString();
                switch (TituloVariante)
                {
                    case "JornadaLaboral":
                        JornadaLaboral = Convert.ToDecimal(drVariable["ValorVariante"].ToString());
                        break;

                    case "DiasSemana":
                        DiaSemana = Convert.ToDecimal(drVariable["ValorVariante"].ToString());
                        break;

                    case "PorceISR":
                        PorceISR = Convert.ToDecimal(drVariable["ValorVariante"].ToString());
                        break;

                    case "ProceVales":
                        PorceVales = Convert.ToDecimal(drVariable["ValorVariante"].ToString());
                        break;

                    case "SemanasMes":
                        SemanasMes = Convert.ToDecimal(drVariable["ValorVariante"].ToString());
                        break;


                }
            }

            //int HorasTrabajadasGeneral = (JornadaLaboral * DiaSemana) * SemanasMes;


            List<EmpleadoNomina> lstEmpleadoNomina = new List<EmpleadoNomina>();
            DataSet ds = dbop.ObtenerNominas_Todas_ByMes(Anio, id);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int HorasT = (Convert.ToInt32(dr["CantEntregadas"].ToString()) > 0 ) ? 192 : 0;
                int idRol = Convert.ToInt32(dr["idRol"].ToString());
                decimal SueldoBase = HorasT * 30;
                decimal Bono = 0, PagoPorEntregas = 0;
                decimal ISR = 0;
               decimal   SueldoTotal = 0;
                decimal vales = 0;
                decimal SueldoFinal = 0;

                PagoPorEntregas = Convert.ToInt32(dr["CantEntregadas"].ToString()) * 5;

                switch (idRol)
                {
                    case 1:
                        Bono = 10 * HorasT;
                        break;
                    case 2:
                        Bono = 5 * HorasT;
                        break;
                }

                SueldoTotal = SueldoBase + Bono + PagoPorEntregas;

                if (SueldoTotal > 10000)
                {
                    ISR = Math.Round(Convert.ToDecimal(SueldoTotal * 0.11M), 2);
                }
                else
                {
                    ISR = Math.Round(Convert.ToDecimal(SueldoTotal * 0.09M), 2);
                }

                vales = Math.Round(Convert.ToDecimal(SueldoTotal * 0.04M), 2);

                SueldoFinal = SueldoTotal - ISR;

                lstEmpleadoNomina.Add(new EmpleadoNomina
                {
                    idEmpleado = Convert.ToInt64(dr["idEmpleado"]),
                    idRol = idRol,
                    Nombre = dr["Nombre"].ToString(),
                    ApePat = dr["ApePat"].ToString(),
                    ApeMat = dr["ApeMat"].ToString(),
                    CantEntregadas = Convert.ToInt32(dr["CantEntregadas"].ToString()),
                    HorasTrabajadas = HorasT,
                    PagoEntregas = PagoPorEntregas,
                    PagoBonos = Bono,
                    ISR = ISR,
                     Vales = vales,
                     SueldoFinal = SueldoFinal
                    




                });
            }


            return lstEmpleadoNomina;
        }
    }
}
