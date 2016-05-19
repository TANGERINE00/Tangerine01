using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M5;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ExcepcionesTangerine;

namespace LogicaTangerine.M5
{
    public class LogicaM5
    {

        /// <summary>
        /// Metodo para consultar contactos de una empresa, sirve para Compania y Cliente Potencial.
        /// </summary>
        /// <param name="typeComp">entero que representa el tipo de empresa a consultar (1 para Compania, 2 para Cliente Potencial)</param>
        /// <param name="idComp">entero que representa el id de la empresa a consultar</param>
        /// <returns>Retorna una lista de contactos de la empresa</returns>
        public List<Contacto> GetContacts(int typeComp, int idComp) 
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
            return BDContacto.ContactCompany(typeComp,idComp); 
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResources.Codigo,
                    LogicResources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(LogicResources.Codigo_Error_Formato,
                     LogicResources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para agregar una contacto nuevo a la empresa.
        /// </summary>
        /// <param name="contact">objeto de tipo Contacto para agregar a la empresa</param>
        /// <returns>true si fue agregado</returns>
        public bool AddNewContact(Contacto contact)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDContacto.AddContact(contact);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResources.Codigo,
                    LogicResources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(LogicResources.Codigo_Error_Formato,
                     LogicResources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para eliminar un contacto de una empresa.
        /// </summary>
        /// <param name="idContact">entero que representa el id del contacto a eliminar de la empresa</param>
        /// <returns>true si fue eliminado</returns>
        public bool DeleteContact(Contacto contact)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDContacto.DeleteContact(contact);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResources.Codigo,
                    LogicResources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(LogicResources.Codigo_Error_Formato,
                     LogicResources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para consultar toda la informacion de un contacto.
        /// </summary>
        /// <param name="idContact">entero que representa el id del contacto a consultar</param>
        /// <returns>Objeto de tipo contacto con los valores</returns>
        public Contacto SearchContact(Contacto contact)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDContacto.SingleContact(contact);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResources.Codigo,
                    LogicResources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(LogicResources.Codigo_Error_Formato,
                     LogicResources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para modificar la informacion de un contacto.
        /// </summary>
        /// <param name="idContact">entero que representa el id del contacto a consultar</param>
        /// <returns>Objeto de tipo contacto con los valores</returns>
        public bool ChangeContact(Contacto contact)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDContacto.ChangeContact(contact);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResources.Codigo,
                    LogicResources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(LogicResources.Codigo_Error_Formato,
                     LogicResources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para Agregar contacto por proyecto.
        /// </summary>
        /// <param name="idContact">entero que representa el id del contacto a consultar</param>
        /// <returns>Objeto de tipo contacto con los valores</returns>
        public bool AddProyectContact(Contacto contact, Proyecto proyect)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDContacto.AddContactProy(contact,proyect);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResources.Codigo,
                    LogicResources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(LogicResources.Codigo_Error_Formato,
                     LogicResources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResources.Mensaje_Generico_Error, ex);
            }
        }
    }
}
