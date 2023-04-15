using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using WebApiRinku.Model;

namespace WebApiRinku.Model
{
    public class db
    {
        public SqlConnection Conecta()
        {
            //clase para conectar a la base de datos obteniendo la configuración del appsetting.json 
            //Para en dado caso que se necesite cambiar la conexión no se tenga que compilar de nuevo 
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration _configuration = builder.Build();
            SqlConnection con = new SqlConnection(_configuration.GetValue<string>("miConfiguracion:ConexionRinKu").ToString());

            return con;
        }


        /// <summary>
        /// Obtiene el listado de empleados activos 
        /// </summary>
        /// <returns></returns>
        public DataSet ObtenerEmpleados_Todos()
        {
            SqlConnection con = Conecta();

            string msg = string.Empty;
            DataSet ds = new DataSet();


          


            try
            {

                SqlCommand COM = new SqlCommand("Empleados_R_Todos", con);
                COM.CommandType = CommandType.StoredProcedure;
                //COM.Parameters.Add
                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                //  return ds;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                {

                }
            }
            return ds;
        }

        /// <summary>
        /// /Obtiene el listado de roles para los catalogos
        /// </summary>
        /// <returns></returns>
        public DataSet ObtenerRoles_Todos()
        {
            SqlConnection con = Conecta();

            string msg = string.Empty;
            DataSet ds = new DataSet();


           


            try
            {

                SqlCommand COM = new SqlCommand("Roles_R_Todos", con);
                COM.CommandType = CommandType.StoredProcedure;
                //COM.Parameters.Add
                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                //  return ds;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                {

                }
            }
            return ds;
        }



        /// <summary>
        /// Obtiene el listado de meses para los catalogos 
        /// </summary>
        /// <returns></returns>
        public DataSet ObtenerMeses_Todos()
        {
            SqlConnection con = Conecta();

            string msg = string.Empty;
            DataSet ds = new DataSet();





            try
            {

                SqlCommand COM = new SqlCommand("Meses_R_Todos", con);
                COM.CommandType = CommandType.StoredProcedure;
                //COM.Parameters.Add
                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                //  return ds;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                {

                }
            }
            return ds;
        }



        /// <summary>
        /// Obtiene todas las nominas por mes
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public DataSet ObtenerNominas_Todas_ByMes(int mes )
        {
            SqlConnection con = Conecta();

            string msg = string.Empty;
            DataSet ds = new DataSet();





            try
            {

                SqlCommand COM = new SqlCommand("NominaEmpleados_R_Todos", con);
                COM.CommandType = CommandType.StoredProcedure;
                COM.Parameters.AddWithValue("@idMes", mes);
              
                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                //  return ds;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                {

                }
            }
            return ds;
        }

        /// <summary>
        /// Obtiene un empleado solamente por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet Empleado_ById(int id)
        {
            SqlConnection con = Conecta();

            string msg = string.Empty;
            DataSet ds = new DataSet();





            try
            {

                SqlCommand COM = new SqlCommand("Empleado_R_ById", con);
                COM.CommandType = CommandType.StoredProcedure;
                COM.Parameters.AddWithValue("@idEmpleado", id);

                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                //  return ds;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                {

                }
            }
            return ds;
        }



        /// <summary>
        /// /Obtiene un movimiento por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet Movimiento_ById(int id)
        {
            SqlConnection con = Conecta();

            string msg = string.Empty;
            DataSet ds = new DataSet();





            try
            {

                SqlCommand COM = new SqlCommand("Movimiento_R_ById", con);
                COM.CommandType = CommandType.StoredProcedure;
                COM.Parameters.AddWithValue("@idMovimiento", id);

                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                //  return ds;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                {

                }
            }
            return ds;
        }


        /// <summary>
        /// Da de alta aun Empleado
        /// </summary>
        /// <param name="Emp"></param>
        /// <returns></returns>

        public DataSet EmpleadoCreate(Empleado Emp)
        {
            SqlConnection con = Conecta();
            string msg = string.Empty;
            DataSet ds = new DataSet();
            
            string Log = "";
            try
            {

                if (Emp.idEmpleado > 0)
                {
                    SqlCommand COM = new SqlCommand("Empleado_U_ById", con);
                    COM.CommandType = CommandType.StoredProcedure;
                    COM.Parameters.AddWithValue("@idEmpleado", Emp.idEmpleado);
                    COM.Parameters.AddWithValue("@Nombre", Emp.Nombre);
                    COM.Parameters.AddWithValue("@ApePat", Emp.ApePat);
                    COM.Parameters.AddWithValue("@ApeMat", Emp.ApeMat);
                    COM.Parameters.AddWithValue("@idRol", Emp.idRol);
                    SqlDataAdapter da = new SqlDataAdapter(COM);
                    da.Fill(ds);
                    msg = "SUCCESS";
                    Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + Emp.Nombre + "," + Emp.ApePat + ", " + Emp.ApeMat + ", " + Emp.idRol + ") -" + msg;

                }
                else
                {
                    SqlCommand COM = new SqlCommand("Empleado_C_Nuevo", con);
                    COM.CommandType = CommandType.StoredProcedure;
                    COM.Parameters.AddWithValue("@Nombre", Emp.Nombre);
                    COM.Parameters.AddWithValue("@ApePat", Emp.ApePat);
                    COM.Parameters.AddWithValue("@ApeMat", Emp.ApeMat);
                    COM.Parameters.AddWithValue("@idRol", Emp.idRol);
                    SqlDataAdapter da = new SqlDataAdapter(COM);
                    da.Fill(ds);
                    msg = "SUCCESS";
                    Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + Emp.Nombre + "," + Emp.ApePat + ", " + Emp.ApeMat + ", " + Emp.idRol + ") -" + msg;

                }

                //  return ds;

            }
            catch (Exception ex)
            {
                msg = "FAILURE";
                //Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + Emp.Nombre + "," + Emp.ApePat + ", " + Emp.ApeMat + ", " + Emp.idRol + ") -" + msg;

                throw;
            }
            finally
            {
                EscribeLog(Log);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return ds;
        }
        /// <summary>
        /// Elimina a un empleado por medio del idEmpleado
        /// </summary>
        /// <param name="idEmpleado"></param>
        /// <returns></returns>
        public string EliminaEmpleado(long  idEmpleado)
        {
            SqlConnection con = Conecta();
            string  msg ="";

            DataSet ds = new DataSet();
            SqlCommand COM = new SqlCommand("BorraEmpleado_U_ById", con);
            string Log = "";
            try
            {


                COM.CommandType = CommandType.StoredProcedure;
                COM.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
               
                msg = "Se Eliminó correctamente el empleado #" + idEmpleado;

                Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + idEmpleado + ") - SUCCESS";


                //  return ds;

            }
            catch (Exception ex)
            {
               
                msg = "Error al eliminar la poliza #" + idEmpleado;
                Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + idEmpleado + ") - ERROR";
                throw;
            }
            finally
            {
                EscribeLog(Log);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }

        /// <summary>
        /// Elimina un movimiento por medio del idMovimiento 
        /// </summary>
        /// <param name="idMovimiento"></param>
        /// <returns></returns>
        public string EliminaMovimiento(long idMovimiento)
        {
            SqlConnection con = Conecta();
            string msg = "";

            DataSet ds = new DataSet();
            SqlCommand COM = new SqlCommand("BorraMovimientoEmpleado_D_ByIdMovimiento", con);
            string Log = "";
            try
            {


                COM.CommandType = CommandType.StoredProcedure;
                COM.Parameters.AddWithValue("@idMovimiento", idMovimiento);
                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);

                msg = "Se Eliminó correctamente el movimiento";

                Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + idMovimiento + ") - SUCCESS";


                //  return ds;

            }
            catch (Exception ex)
            {

                msg = "Error al eliminar la el movimiento";
                Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + idMovimiento + ") - ERROR";
                throw;
            }
            finally
            {
                EscribeLog(Log);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return msg;
        }

        /// <summary>
        /// Da de alta un nuevo Movimiento 
        /// </summary>
        /// <param name="Mov"></param>
        /// <returns></returns>
        public DataSet MovimientoCreate(Movimiento Mov)
        {
            string Log = "";
            SqlConnection con = Conecta();
            string msg = string.Empty;
            DataSet ds = new DataSet();
            if (Mov.idMovimiento > 0)
            {
                SqlCommand COM = new SqlCommand("MovimientoEmpleado_U_ByIdMovimiento", con);
                COM.CommandType = CommandType.StoredProcedure;
                COM.Parameters.AddWithValue("@idMovimiento", Mov.idMovimiento);
                COM.Parameters.AddWithValue("@idRol", Mov.idRol);
                COM.Parameters.AddWithValue("@idMes", Mov.idMes);
                COM.Parameters.AddWithValue("@CantEntregadas", Mov.CantEntrega);
                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + Mov.idEmpleado + "," + Mov.idRol + ", " + Mov.idMes + ", " + Mov.CantEntrega + ") -" + msg;


            }
            else
            {
                SqlCommand COM = new SqlCommand("MovimientoEmpleado_C_Nuevo", con);
                COM.CommandType = CommandType.StoredProcedure;
                COM.Parameters.AddWithValue("@idEmpleado", Mov.idEmpleado);
                COM.Parameters.AddWithValue("@idRol", Mov.idRol);
                COM.Parameters.AddWithValue("@idMes", Mov.idMes);
                COM.Parameters.AddWithValue("@CantEntregadas", Mov.CantEntrega);
                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + Mov.idEmpleado + "," + Mov.idRol + ", " + Mov.idMes + ", " + Mov.CantEntrega + ") -" + msg;

            }

            
            try
            {


               //  return ds;

            }
            catch (Exception ex)
            {
                msg = "FAILURE";
               // Log = COM.Connection.ConnectionString.ToString() + "-" + COM.CommandText.ToString() + "(" + Mov.idEmpleado + "," + Mov.idRol + ", " + Mov.idMes + ", " + Mov.CantEntrega + ") -" + msg;

                throw;
            }
            finally
            {
                EscribeLog(Log);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return ds;
        }



        /// <summary>
        /// Guarda el mensaje que le pase como parametro en un log 
        /// </summary>
        /// <param name="message"></param>

        public static void EscribeLog(string message)
        {

            string path = "C://RinKu//Log2.txt";
            StreamWriter stream = null;
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }



                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(string.Format("{0} - {1}.", DateTime.Now, message));
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public DataSet ObtenerMovimientos_ByidEmpleado(long  idEmpleado)
        {
            SqlConnection con = Conecta();

            string msg = string.Empty;
            DataSet ds = new DataSet();





            try
            {

                SqlCommand COM = new SqlCommand("MovimientoEmpleado_R_ByIdEmpleado", con);
                COM.CommandType = CommandType.StoredProcedure;
                COM.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                SqlDataAdapter da = new SqlDataAdapter(COM);
                da.Fill(ds);
                msg = "SUCCESS";
                //  return ds;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                {

                }
            }
            return ds;
        }


    }
}
