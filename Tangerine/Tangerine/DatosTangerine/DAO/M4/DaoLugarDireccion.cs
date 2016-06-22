using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M4;
using DominioTangerine.Entidades.M4;
using DominioTangerine;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M4;

namespace DatosTangerine.DAO.M4
{
    public class DaoLugarDireccion : DAOGeneral,IDaoLugarDireccion
    {
      
       public bool Agregar(Entidad parametro)
       {
           throw new NotImplementedException();
       }

       public bool Modificar(Entidad parametro)
       {
           throw new NotImplementedException();
       }

       /// <summary>
       /// Método para consultar un lugar en especifico
       /// </summary>
       /// <returns>Lista de lugares.</returns>

       public Entidad ConsultarXId(Entidad parametro)
       {
           Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
           ResourceCompanyM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           Parametro theParam = new Parametro();
           Entidad thePlace;

           try
           {
               List<Parametro> parameters = new List<Parametro>();

               //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
               //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
               theParam = new Parametro(ResourcePlaceM4.ParamId, SqlDbType.Int,
                     ((DominioTangerine.Entidades.M4.LugarDireccionM4)parametro).LugId.ToString(), false);
               parameters.Add(theParam);

               //Guardo la tabla que me regresa el procedimiento de consultar contactos
               DataTable dt = EjecutarStoredProcedureTuplas(ResourcePlaceM4.ConsultCityId, parameters);

               //Por cada fila de la tabla voy a guardar los datos 
               DataRow row = dt.Rows[0];
               

                   int lugId = int.Parse(row[ResourcePlaceM4.LugIdPlace].ToString());
                   String lugName = row[ResourcePlaceM4.LugNamePlace].ToString();
                   String lugTypePlace = row[ResourcePlaceM4.LugTypePlace].ToString();
                   int LugLugIdPlace = int.Parse(row[ResourcePlaceM4.LugLugIdPlace].ToString());
                   thePlace = DominioTangerine.Fabrica.FabricaEntidades.crearLugarDireccionCuatroParametros(lugId, lugName, lugTypePlace, LugLugIdPlace);

               
               return thePlace;

           }
           catch (ArgumentNullException ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExceptionM4Tangerine("DS-404", "Ingreso de un argumento con valor invalido", ex);
           }
           catch (FormatException ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExceptionM4Tangerine("DS-404", "Ingreso de datos con un formato invalido", ex);
           }
           catch (SqlException ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExceptionM4Tangerine("DS-404", "Error al momento de realizar la conexion", ex);
           }
           catch (Exception ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExceptionM4Tangerine("DS-404", "Error al momento de realizar la operacion ", ex);
           }
       }

       public List<Entidad> ConsultarTodos()
       {
           throw new NotImplementedException();
       }


       /// <summary>
       /// Método para consultar los lugares con sus nombres y sus id.
       /// </summary>
       /// <returns>Lista de lugares.</returns>

       public List<Entidad> ConsultCityPlaces()
       {
           Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
           ResourceCompanyM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           List<Parametro> parameters = new List<Parametro>();
           List<Entidad> listPlace = new List<Entidad>();

           try
           {

               //Guardo la tabla que me regresa el procedimiento de consultar contactos
               DataTable dt = EjecutarStoredProcedureTuplas(ResourcePlaceM4.ConsultCityPlaces, parameters);

               //Por cada fila de la tabla voy a guardar los datos 
               foreach (DataRow row in dt.Rows)
               {

                   int lugId = int.Parse(row[ResourcePlaceM4.LugIdPlace].ToString());
                   String lugName = row[ResourcePlaceM4.LugNamePlace].ToString();

                   Entidad thePlace = DominioTangerine.Fabrica.FabricaEntidades.crearLugarDireccionConLugar(lugId, lugName);
                   listPlace.Add(thePlace);
               }
               return listPlace;

           }
           catch (ArgumentNullException ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExceptionM4Tangerine("DS-404", "Ingreso de un argumento con valor invalido", ex);
           }
           catch (FormatException ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExceptionM4Tangerine("DS-404", "Ingreso de datos con un formato invalido", ex);
           }
           catch (SqlException ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExceptionM4Tangerine("DS-404", "Error al momento de realizar la conexion", ex);
           }
           catch (Exception ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExceptionM4Tangerine("DS-404", "Error al momento de realizar la operacion ", ex);
           }
       }

     
    }
}
