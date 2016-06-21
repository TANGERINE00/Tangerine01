using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;



namespace LogicaTangerine.M3
{
    public class LogicaM3
    {
        
        //----------------------------------  listar cliente potencial------------------------------------------------
//        public List<ClientePotencial> LogicalistarClientePotencial()
//        {
//            try
//            {
//                return BDClientePotencial.DatosListarClientePotencial();
//            }
//            catch (ArgumentNullException ex)
//            {

//                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (SqlException ex)
//            {

//                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (FormatException ex)
//            {

//                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(LogicaM3Resources.Codigo_Error_Formato,
//                     LogicaM3Resources.Mensaje_Error_Formato, ex);
//            }
//            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
//            {
//                throw ex;
//            }
//            catch (Exception ex)
//            {
//                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM3Resources.Mensaje_Generico_Error, ex);
//            }
//        }
////----------------------------------------agregar cliente Potencial -------------------------------------------------

        

//        public bool AgregarNuevoclientePotencial(ClientePotencial elClientePotencial)
//        {
//            try
//            {
//                return BDClientePotencial.AgregarClientePotencial(elClientePotencial);
//            }
//            catch (ArgumentNullException ex)
//            {

//                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (SqlException ex)
//            {

//                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (FormatException ex)
//            {

//                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(LogicaM3Resources.Codigo_Error_Formato,
//                     LogicaM3Resources.Mensaje_Error_Formato, ex);
//            }
//            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
//            {
//                throw ex;
//            }
//            catch (Exception ex)
//            {
//                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM3Resources.Mensaje_Generico_Error, ex);
//            }
//        }
//        //------------------------------------consultar un cliente en especifico-------------
//        public ClientePotencial BuscarClientePotencial(int idClientePotencial)
//        {
//            try
//            {
//                return BDClientePotencial.ConsultarClientePotencial(idClientePotencial);
//            }
//            catch (ArgumentNullException ex)
//            {

//                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (SqlException ex)
//            {

//                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (FormatException ex)
//            {

//                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(LogicaM3Resources.Codigo_Error_Formato,
//                     LogicaM3Resources.Mensaje_Error_Formato, ex);
//            }
//            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
//            {
//                throw ex;
//            }
//            catch (Exception ex)
//            {
//                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM3Resources.Mensaje_Generico_Error, ex);
//            }
//        }
//   //--------------------------------------------borrar cliente-------------------


//        public bool BorrarNuevoclientePotencial(ClientePotencial elClientePotencial)
//        {
//            try
//            {
//                return BDClientePotencial.BorrarClientePotencial(elClientePotencial);
//            }
//            catch (ArgumentNullException ex)
//            {

//                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (SqlException ex)
//            {

//                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (FormatException ex)
//            {

//                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(LogicaM3Resources.Codigo_Error_Formato,
//                     LogicaM3Resources.Mensaje_Error_Formato, ex);
//            }
//            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
//            {
//                throw ex;
//            }
//            catch (Exception ex)
//            {
//                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM3Resources.Mensaje_Generico_Error, ex);
//            }
//        }



//        public bool ModificarNuevoclientePotencial(ClientePotencial elClientePotencial)
//        {
//            try
//            {
//                return BDClientePotencial.ModificarClientePotencial(elClientePotencial);
//            }
//            catch (ArgumentNullException ex)
//            {

//                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (SqlException ex)
//            {

//                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (FormatException ex)
//            {

//                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(LogicaM3Resources.Codigo_Error_Formato,
//                     LogicaM3Resources.Mensaje_Error_Formato, ex);
//            }
//            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
//            {
//                throw ex;
//            }
//            catch (Exception ex)
//            {
//                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM3Resources.Mensaje_Generico_Error, ex);
//            }
//        }

//        public bool ActivarclientePotencial(ClientePotencial elClientePotencial)
//        {
//            try
//            {
//                return BDClientePotencial.ActivarClientePotencial(elClientePotencial);
//            }
//            catch (ArgumentNullException ex)
//            {

//                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (SqlException ex)
//            {

//                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (FormatException ex)
//            {

//                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(LogicaM3Resources.Codigo_Error_Formato,
//                     LogicaM3Resources.Mensaje_Error_Formato, ex);
//            }
//            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
//            {
//                throw ex;
//            }
//            catch (Exception ex)
//            {
//                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM3Resources.Mensaje_Generico_Error, ex);
//            }
//        }


//        public bool PromoverclientePotencial(ClientePotencial elClientePotencial)
//        {
//            try
//            {
//                return BDClientePotencial.PromoverClientePotencial(elClientePotencial);
//            }
//            catch (ArgumentNullException ex)
//            {

//                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (SqlException ex)
//            {

//                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaM3Resources.Codigo,
//                    LogicaM3Resources.Mensaje, ex);
//            }
//            catch (FormatException ex)
//            {

//                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(LogicaM3Resources.Codigo_Error_Formato,
//                     LogicaM3Resources.Mensaje_Error_Formato, ex);
//            }
//            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
//            {
//                throw ex;
//            }
//            catch (Exception ex)
//            {
//                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaM3Resources.Mensaje_Generico_Error, ex);
//            }
//        }

    
    }
}
