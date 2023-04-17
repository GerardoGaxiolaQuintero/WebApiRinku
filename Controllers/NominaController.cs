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

        /// <summary>
        /// Muestra el listado de la nómina de todos los trabajadores activos consultada por el año y mes 
        /// </summary>
        /// <param name="Anio"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public List<EmpleadoNomina> ListadoNomina(string Anio,int id)
        {

            ///Consultamos las variables para cancular la nomina 

            List<Variable> Variables = new List<Variable>();

            ///Consultamos todos los datos variables plasmados en un catalogo necesario para calcular la nomina 
            DataSet dsVariables = dbop.ObtenerVariablesNomina(Anio);

            decimal JornadaLaboral = 0, DiaSemana = 0, PorceISR = 0, PorceVales = 0, SemanasMes = 0;

            
            //REcorremos estos datos y los guardamos en sus respectivas variables 
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

            ///Calculamos las horas trabajadas 
            int HorasTrabajadasGeneral = decimal.ToInt32((JornadaLaboral * DiaSemana) * SemanasMes);


            List<EmpleadoNomina> lstEmpleadoNomina = new List<EmpleadoNomina>();

            //obtenemos el listado de todos los empleados activos para empezar con el cálculo de la nomina 
            DataSet ds = dbop.ObtenerNominas_Todas_ByMes(Anio, id);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //si no tiene capturadas entregas tomamos en cuenta 0 horas trabajadas 
                int HorasT = (Convert.ToInt32(dr["CantEntregadas"].ToString()) > 0 ) ? HorasTrabajadasGeneral : 0;
                int idRol = Convert.ToInt32(dr["idRol"].ToString());
                ///calculamos el sueldo base 
                decimal SueldoBase = HorasT * Convert.ToDecimal(dr["SueldoBasePH"].ToString());
                decimal Bono = 0, PagoPorEntregas = 0;
                decimal ISR = 0;
                decimal ISRTOTAL = 0;
               decimal   SueldoTotal = 0;
                decimal vales = 0;
                decimal SueldoFinal = 0;

                //Calculamos el pago por entregas 
                PagoPorEntregas = Convert.ToInt32(dr["CantEntregadas"].ToString()) * Convert.ToDecimal(dr["PagoPorEntrega"].ToString());

             
                //Calculamos el bono por hora por empleado 
                Bono = HorasT * Convert.ToDecimal(dr["BonoPorHora"].ToString());

                SueldoTotal = SueldoBase + Bono + PagoPorEntregas;

               
               
                //Obtenmos el descuento extra(Si lo existe ) calculado en base al sueldo
                DataSet dsDescExtra = dbop.ObtenerDescuentosExtras_BySueldo(SueldoTotal, Anio);


                foreach (DataRow drDE in dsDescExtra.Tables[0].Rows)
                {
                    //Si se encuentra impuesto extra este se le suma al convencional 
                    ISRTOTAL = PorceISR + Convert.ToDecimal(drDE["Porcentaje"].ToString());
                }


                ISR =  Math.Round(Convert.ToDecimal(SueldoTotal * ISRTOTAL), 2);

                //ISR += CantImpuestoExtra;

                SueldoFinal = SueldoTotal - ISR;






                vales = Math.Round(Convert.ToDecimal(SueldoFinal * PorceVales), 2);

               
                ///Guardamos el Objeto EmpleadoNomina para mostrar el listado con todos los calculos 
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
