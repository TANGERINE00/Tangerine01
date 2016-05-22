using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M10;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ExcepcionesTangerine;

namespace LogicaTangerine.M10
{
    public class LogicaM10
    {
        public Empleado theEmpleado;

        /// <summary>
        /// Metodo para agregar un empleado.
        /// </summary>
        /// <param name="empleado">objeto que representa el empleado a agregar</param>
        /// <returns>true si fue agregado</returns>
        public bool AddNewEmpleado(Empleado empleado)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.AddEmpleado(empleado);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para consultar todos los empleados
        /// </summary>
        /// <returns>Retorna una lista de empleados</returns>
        public List<Empleado> GetEmpleados()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.ListarEmpleados();
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para obtener un empleado dado su numero de ficha.
        /// </summary>
        /// <param name="employeeId">Número entero que representa el número de ficha del empleado</param>
        /// <returns>Objeto de tipo Empleado</returns>
        public Empleado GetEmployee(int employeeId)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.GetEmployeeById(employeeId);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para obtener una lista de Lugares de tipo "Pais".
        /// </summary>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public List<LugarDireccion> ItemsForListCountry()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.GetElementsForSelectCountry();
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para obtener una lista de Lugares de tipo "Estado".
        /// </summary>
        /// <param name="country">Cadena de caracteres que representa el Pais a filtrar</param>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public List<LugarDireccion> ItemsForListState(string country)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.GetElementsForSelectState(country);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para obtener una lista de Cargos
        /// </summary>
        /// <returns>Lista de objetos de tipo de Cargo</returns>
        public List<Cargo> ItemsForListJobs()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.GetElementsForSelectJob();
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para obtener una lista de Empleados con cargo de Gerente
        /// </summary>
        /// <returns>Lista de objetos de tipo Empleado </returns>
        public List<Empleado> GetGerentes()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.ListarGerentes();
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para obtener una lista de Empleados con cargo de Programador
        /// </summary>
        /// <returns>Lista de objetos de tipo Empleado </returns>
        public List<Empleado> GetProgramadores()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.ListarProgramadores();
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }

        /// <summary>
        /// Metodo para cambiar el estatus de un empleado de activo a inactivo o viceversa.
        /// </summary>
        /// <param name="empleado">Número entero que representa la ficha del empleado</param>
        /// <returns>true si modifica el estatus</returns>
        public bool CambiarEstatus(int empleado)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                LogicaM10Resources.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return BDEmpleado.CambiarEstatus(empleado);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM10Resources.Codigo,
                    LogicaM10Resources.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.WrongFormatException(LogicaM10Resources.Codigo_Error_Formato,
                     LogicaM10Resources.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM10Resources.Mensaje_Generico_Error, ex);
            }
        }
    }
}
