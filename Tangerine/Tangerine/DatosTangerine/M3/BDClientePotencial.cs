using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;


namespace DatosTangerine.M3
{
    public class BDClientePotencial
    {
  //     -----------------------------Listar Clientes Potencial ---------------------------------------------
       public List<ClientePotencial> DatosListarClientePotencial()
        {
            List<ClientePotencial> objetolistaClientePotencial = new List<ClientePotencial>();

           // List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            Boolean exito = false;
            List<Parametro> parametros = new List<Parametro>();

            //BDConexion conexion = new BDConexion();
            DataTable data = new DataTable();
            data = theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.SP_listarClientePotencial, parametros);
            foreach (DataRow row in data.Rows)
                
            {
                //Empleado empleado = new Empleado();
                ClientePotencial clientePotencial = new ClientePotencial();

          //      clientePotencial.IdClientePotencial = Int32.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());
                clientePotencial.NombreClientePotencial = row[ResourceClientePotencial.nombreClientePotencial].ToString();
                //ese nombre en mayuscula es el del set y el get de la capa de dominio

                clientePotencial.RifClientePotencial = row[ResourceClientePotencial.rifClientePotencial].ToString();
                clientePotencial.EmailClientePotencial = row[ResourceClientePotencial.emailClientePotencial].ToString();
                clientePotencial.PresupuestoAnual_inversion = float.Parse(row[ResourceClientePotencial.presupuestoAnual_inversion].ToString());



                objetolistaClientePotencial.Add(clientePotencial);

            }

            return objetolistaClientePotencial;

        }
//------------------------------------------------------termino del listar cliente potencial -------------




        //public static bool AddContact(Contacto theContact)
            public static bool AgregarClientePotencial(ClientePotencial elClientePotencial)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceClientePotencial.AnombreClientePotencial, SqlDbType.VarChar, elClientePotencial.NombreClientePotencial, false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceClientePotencial.ArifClientePotencial, SqlDbType.VarChar, elClientePotencial.RifClientePotencial, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.AemailClientePotencial, SqlDbType.VarChar, elClientePotencial.EmailClientePotencial, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.ApresupuestoAnualInversion, SqlDbType.Decimal, elClientePotencial.PresupuestoAnual_inversion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.AnumLlamadas, SqlDbType.Int, elClientePotencial.NumeroLlamadas.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.AnumVisitas, SqlDbType.Int, elClientePotencial.NumeroVisitas.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.Apotencial, SqlDbType.Bit, elClientePotencial.Potencial.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.Aborrado, SqlDbType.Bit, elClientePotencial.Borrado.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_agregar_clientePotencial, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }
    }
}
