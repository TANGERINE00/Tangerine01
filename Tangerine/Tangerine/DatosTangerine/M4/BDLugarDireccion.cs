using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;
using ExcepcionesTangerine;

namespace DatosTangerine.M4
{
    public class BDLugarDireccion
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        /// <summary>
        /// Método para consultar todos los lugares tipo 'Ciudad' registradas en la base de datos.
        /// </summary>
        /// <returns>Lista de lugares registrados.</returns>
        public static List<LugarDireccion> ConsultPlaces()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceCompany.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            List<LugarDireccion> listPlace = new List<LugarDireccion>();

            try
            {
                theConnection.Conectar();

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourcePlace.ConsultPlaces, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int lugId = int.Parse(row[ResourcePlace.LugIdPlace].ToString());
                    String lugName = row[ResourcePlace.LugNamePlace].ToString();

                    LugarDireccion thePlace = new LugarDireccion(lugId, lugName);
                    listPlace.Add(thePlace);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return listPlace;
        }

    }

}
