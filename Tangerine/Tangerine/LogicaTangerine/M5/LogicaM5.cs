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
        /// <param name="contact">objeto que representa el contacto a eliminar de la empresa</param>
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
        /// <param name="contact">objeto que representa el contacto a consultar</param>
        /// <returns>Objeto de tipo contacto con todos sus valores</returns>
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
        /// <param name="contact">objeto que representa el contacto a modificar</param>
        /// <returns>true si fueron cambiados sus valores</returns>
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
        /// Metodo para Agregar contacto a un proyecto.
        /// </summary>
        /// <param name="contact">objeto que representa el contacto a agregar a proyecto</param>
        /// <param name="proyect">objeto que representa el proyecto a agregar contacto</param>
        /// <returns>true si agrega el contacto al proyecto</returns>
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

        /// <summary>
        /// Metodo para traer todos los contacto de un proyecto.
        /// </summary>
        /// <param name="proyect">objeto por el cual se va a traer sus contactos</param>
        /// <returns>Lista de contactos del proyecto</returns>
        public List<Contacto> GetContactsProyect(Proyecto proyect)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDContacto.ContactProyect(proyect);
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
        /// Metodo para eliminar un contacto de un proyecto.
        /// </summary>
        /// <param name="contact">objeto de tipo contacto a eliminar de proyecto</param>
        /// <param name="proyect">objeto de tipo proyecto a quitar el contacto</param>
        /// <returns>True si elimina el contacto del proyecto</returns>
        public bool DeleteContactProyect(Contacto contact, Proyecto proyect)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDContacto.DeleteContactProyect(contact, proyect);
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
        /// Metodo para traer todos los contacto que no estan asignados al proyecto.
        /// Trae los que no tiene asignado y que son de la misma compania del proyecto
        /// </summary>
        /// <param name="proyect">objeto proyecto a consultar los contactos que no tiene asignados</param>
        /// <returns>Lista de contactos del proyecto</returns>
        public List<Contacto> GetContactsNoProyect(Proyecto proyect)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, LogicResources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDContacto.ContactNoProyect(proyect);
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
