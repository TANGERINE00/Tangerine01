using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M4;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ExcepcionesTangerine;

namespace LogicaTangerine.M4
{
    public class LogicaM4
    {
        public Compania theCompany;

        public void init()
        {
        }

        /// <summary>
        /// Método para consultar todas las compañías en la base de datos.
        /// </summary>
        /// <returns>Lista de compañías</returns>
        public List<Compania> ConsultCompanies()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
             try
            {
                return BDCompania.ConsultCompanies(); 
            }
             catch (ArgumentNullException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                     LogicResourcesM4.Mensaje, ex);
             }
             catch (SqlException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                 throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                     LogicResourcesM4.Mensaje, ex);
             }
             catch (FormatException ex)
             {
                 Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                 throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                      LogicResourcesM4.Mensaje_Error_Formato, ex);
             }
             catch (ExcepcionesTangerine.ExceptionTGConBD ex)
             {
                 throw ex;
             }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Método para insertar una nueva compañía en la base de datos.
        /// </summary>
        /// <param name="company">Objeto tipo Compania que representa la empresa a insertar.</param>
        /// <returns>True si fue insertada exitosamente.</returns>
        public bool AddNewCompany(Compania company)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDCompania.AddCompany(company);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                     LogicResourcesM4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }
        
        /// <summary>
        /// Método para modificar la informacion de un compania en la base de datos.
        /// </summary>
        /// <param name="company">Objeto tipo compania que representa a la compania a ser modificada.</param>
        /// <returns>True si fue modificada exitosamente.</returns>
        public bool ChangeCompany(Compania company)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return (BDCompania.ChangeCompany(company));
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                     LogicResourcesM4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }
        
        /// <summary>
        /// Método para consultar una compañía en específico en la base de datos.
        /// </summary>
        /// <param name="idCompany">Entero que contiene al id de la compañía a modificar.</param>
        /// <returns>Objeto tipo Compania que contiene a la empresa consultada.</returns>
        public Compania ConsultCompany(int idCompany)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDCompania.ConsultCompany(idCompany);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                     LogicResourcesM4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }
        
        /// <summary>
        /// Método para habilitar una compañía.
        /// </summary>
        /// <param name="company">Objeto tipo Compania que contiene a la compañía a habilitar.</param>
        /// <returns>True si fue habilitada exitosamente.</returns>
        public bool EnableCompany(Compania company)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return(BDCompania.EnableCompany(company));
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                     LogicResourcesM4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Método para deshabilitar una compañía.
        /// </summary>
        /// <param name="company">Objeto tipo Compania que contiene a la compañía a deshabilitar.</param>
        /// <returns>True si fue deshabilitada exitosamente.</returns>
        public bool DisableCompany(Compania company)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return (BDCompania.DisableCompany(company));
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                     LogicResourcesM4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }
        
        /// <summary>
        /// Método para consultar todas las ciudades en la base de datos.
        /// </summary>
        /// <returns>Lista de lugares.</returns>
        public List<LugarDireccion> getPlaces()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDLugarDireccion.ConsultCityPlaces();
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                     LogicResourcesM4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Método para consultar nombre de una ciudad por su id en la base de datos.
        /// </summary>
        /// <param name="idLugar">entero que contiene al id del lugar a consultar.</param>
        /// <returns>String correspondiente al nombre del lugar.</returns>
        public string MatchNombreLugar(int idLugar)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                string NombreLugar = "";
                foreach (LugarDireccion lugar in BDLugarDireccion.ConsultCityPlaces())
                {
                    if (idLugar.Equals(lugar.LugId))
                    {
                        NombreLugar = lugar.LugNombre;
                    }
                }

                return NombreLugar;
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                     LogicResourcesM4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Método para consultar id de una ciudad por su nombre en la base de datos.
        /// </summary>
        /// <param name="nombreLugar">String que contiene al nombre del lugar a consultar.</param>
        /// <returns>Entero correspondiente al id del lugar.</returns>
        public int MatchIdLugar(string nombreLugar)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicResourcesM4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                int IdLugar = 0;
                foreach (LugarDireccion lugar in BDLugarDireccion.ConsultCityPlaces())
                {
                    if (nombreLugar.Equals(lugar.LugNombre))
                    {
                        IdLugar = lugar.LugId;
                    }
                }

                return IdLugar;
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM4.Codigo,
                    LogicResourcesM4.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M4.WrongFormatException(LogicResourcesM4.Codigo_Error_Formato,
                     LogicResourcesM4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicResourcesM4.Mensaje_Generico_Error, ex);
            }
        }
    }
}
