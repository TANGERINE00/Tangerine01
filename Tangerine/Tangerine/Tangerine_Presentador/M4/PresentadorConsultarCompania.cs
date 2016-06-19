using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Tangerine_Contratos.M4;
using LogicaTangerine;
using DominioTangerine;

namespace Tangerine_Presentador.M4
{
    public class PresentadorConsultarCompania
    {
        #region InicializarVista
        IContratoConsultarCompania _vista;
        Entidad _entidad;

        public PresentadorConsultarCompania(IContratoConsultarCompania vista)
        {

            this._vista = vista;

        }
        #endregion

        #region CargarInformacionCompania

       /* public void CargarCompania() 
        {
            Compania laCompania;
            int idComp, typeHab;
            try
            {
                typeHab = int.Parse(Request.QueryString["typeHab"]);
                idComp = int.Parse(Request.QueryString["idComp"]);
                laCompania = prueba.ConsultCompany(idComp);
                if (typeHab == 1)
                {
                    prueba.EnableCompany(laCompania);

                }
                if (typeHab == 0)
                {
                    prueba.DisableCompany(laCompania);
                }
            }
            catch
            {
            }

            imprimirTabla();  
        }*/

        public void ImprimirCompania() 
        {
            try
            {
                Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarTodasCompania();
                List<Entidad> listaCompanias = comando.Ejecutar();

                foreach (Entidad company in listaCompanias)
                {
                    _vista.Tabla.Text += RecursosPresentadorM4.OpenTR;
                    _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)company).NombreCompania.ToString() + RecursosPresentadorM4.CloseTD;
                    //company += ResourceGUIM4.OpenTD + theCompany.AcronimoCompania.ToString() + ResourceGUIM4.CloseTD;
                    _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)company).RifCompania + RecursosPresentadorM4.CloseTD;
                    _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)company).TelefonoCompania + RecursosPresentadorM4.CloseTD;
                    //company += ResourceGUIM4.OpenTD + theCompany.FechaRegistroCompania.ToString() + ResourceGUIM4.CloseTD;

                    if (((DominioTangerine.Entidades.M4.CompaniaM4)company).StatusCompania.Equals(1))
                    {
                        _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + RecursosPresentadorM4.habilitado + ((DominioTangerine.Entidades.M4.CompaniaM4)company).Id +
                            RecursosPresentadorM4.CloseSpanHab + RecursosPresentadorM4.CloseTD;
                    }
                    else if (((DominioTangerine.Entidades.M4.CompaniaM4)company).StatusCompania.Equals(0))
                    {
                        _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + RecursosPresentadorM4.inhabilitado + ((DominioTangerine.Entidades.M4.CompaniaM4)company).Id +
                            RecursosPresentadorM4.CloseSpanInhab + RecursosPresentadorM4.CloseTD;
                    }

                    //Acciones de cada compania  
                    imprimirBotonesAccion(company);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void imprimirBotonesAccion(Entidad theCompany)
        {
            /*if (HttpContext.Current.Session["Rol"].Equals("Administrador") ||
                        HttpContext.Current.Session["Rol"].Equals("Gerente"))
            {*/
                _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + RecursosPresentadorM4.OpenDivRow +
                RecursosPresentadorM4.OpenBotonInfo + theCompany.Id + //Boton Info 
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.OpenBotonEdit + theCompany.Id + //Boton Edit 
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.OpenBotonHab + theCompany.Id + //Boton Habilitar 
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.OpenBotonInhab + theCompany.Id + //Boton Inhabilitar
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.BotonInvol + theCompany.Id + //Boton Contacto
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.CloseDiv +
                RecursosPresentadorM4.CloseTD;

                _vista.Tabla.Text += RecursosPresentadorM4.CloseTR;
           // }
           /* else if (HttpContext.Current.Session["Rol"].Equals("Programador") ||
                     HttpContext.Current.Session["Rol"].Equals("Director"))
            {
                _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + RecursosPresentadorM4.OpenDivRow +
                RecursosPresentadorM4.OpenBotonInfo + theCompany.Id + //Boton Info 
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.BotonInvol + theCompany.Id + //Boton Contacto
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.CloseDiv +
                RecursosPresentadorM4.CloseTD;

                _vista.Tabla.Text += RecursosPresentadorM4.CloseTR;
            }*/
        }
        #endregion
    }
}
