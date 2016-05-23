using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M8;
using System.Data.SqlClient;
using ExcepcionesTangerine;

namespace LogicaTangerine.M8
{
    public class LogicaM8
    {
        public Facturacion theFactura;
        List<Facturacion> answer;
        bool answer2;
        

        public void init()
        {

        }

        public List<Facturacion> getFacturas()
        {
            try
            {
                return BDFactura.ContactFacturas();
            }
          catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }
        

        public bool AddNewFactura( Facturacion factura )
        {
            try
            {
                return BDFactura.AddFactura(factura);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public bool ChangeExistingFactura( Facturacion factura )
        {
            try
            {
                return BDFactura.ChangeFactura(factura);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public bool AnnularFactura(Facturacion factura)
        {
            try
            {
                return BDFactura.AnnularFactura(factura);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public Facturacion SearchFactura( int idFactura )
        {
            try
            {
                return BDFactura.ContactFactura(idFactura);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public Compania SearchCompaniaFactura( int idCompania )
        {
            try
            {
                return BDFactura.ConsultCompany(idCompania);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public Proyecto SearchProyectoFactura(int idProyecto)
        {
            try
            {
                return BDFactura.ContactProyectoFactura( idProyecto );
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public List<Facturacion> SearchFacturasCompania(int idCompania)
        {
            try
            {
                return BDFactura.ContactFacturasCompania(idCompania);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public List<Facturacion> SearchFacturasPagadasCompania(int idCompania)
        {
            try
            {
                return BDFactura.ContactFacturasPagadasCompania(idCompania);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public double SearchMontoRestanteFactura(int idFactura)
        {
            try
            {
                return BDFactura.ContactMontoRestanteFactura(idFactura);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }

        public bool SearchExistingBill(DateTime fechaEmision, int idProyecto, int idCompania)
        {
            try
            {
                return BDFactura.CheckExistingInvoice(fechaEmision, idProyecto, idCompania);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo_Error_Formato,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceLogicaM8.Mensaje_Generico_Error, ex);
            }
        }
    }
}
