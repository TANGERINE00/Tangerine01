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
using ExcepcionesTangerine.M4;

namespace Tangerine_Presentador.M4
{
    public class PresentadorConsultarCompania
    {
        #region InicializarVista
        IContratoConsultarCompania _vista;
        Entidad _entidad;

        /// <summary>
        /// Constructor que permite inicializar la vista dentro del presentador
        /// </summary>
        public PresentadorConsultarCompania(IContratoConsultarCompania vista)
        {

            this._vista = vista;

        }
        #endregion

        #region CargarInformacionCompania
        /// <summary>
        /// Metodo que permite inahilitar una compania
        /// </summary>

        public Boolean BotonHabilitarInhabilitar(int typeHab, int idComp) 
        {
            try
            {
                Entidad compania = DominioTangerine.Fabrica.FabricaEntidades.CrearCompaniaVacia();
                ((DominioTangerine.Entidades.M4.CompaniaM4)compania).Id = idComp;
                
                if (typeHab == 1)
                {
                    Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearHabilitarCompania(compania);
                    comando.Ejecutar();

                }
                if (typeHab == 0)
                {
                    Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearDeshabilitarCompania(compania);
                    comando.Ejecutar();
                }
                return true;
            }
            catch (ExceptionM4Tangerine ex)
            {
                _vista.msjError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Metodo que muestra las companias por pantalla
        /// </summary>

        public Boolean ImprimirCompania(string Rol) 
        {
            try
            {
                Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarTodasCompania();
                List<Entidad> listaCompanias = comando.Ejecutar();

                foreach (Entidad company in listaCompanias)
                {
                    _vista.Tabla.Text += RecursosPresentadorM4.OpenTR;
                    _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)company).NombreCompania.ToString() + RecursosPresentadorM4.CloseTD;
                    _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)company).RifCompania + RecursosPresentadorM4.CloseTD;
                    _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)company).TelefonoCompania + RecursosPresentadorM4.CloseTD;
               
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
                    imprimirBotonesAccion(company,Rol);
                }
                return true;
            }
            catch (ExceptionM4Tangerine ex)
            {
                _vista.msjError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Metodo que muestra los botones que se encuentran en la pantalla dependiendo del usuario logueado
        /// </summary>
        public void imprimirBotonesAccion(Entidad theCompany, string Rol)
        {
            if (Rol.Equals("Administrador") || Rol.Equals("Gerente"))
            {
                _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + RecursosPresentadorM4.OpenDivRow +
                RecursosPresentadorM4.OpenBotonInfo + theCompany.Id + //Boton Info 
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.OpenBotonEdit + theCompany.Id + //Boton Edit 
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.OpenBotonHab + theCompany.Id + //Boton Habilitar 
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.OpenBotonInhab + theCompany.Id + //Boton Inhabilitar
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.BotonInvol + theCompany.Id + //Boton Contacto
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.CloseDiv +
                RecursosPresentadorM4.CloseTD;

                _vista.Tabla.Text += RecursosPresentadorM4.CloseTR;
            }
            else if (Rol.Equals("Programador") || Rol.Equals("Director"))
            {
                _vista.Tabla.Text += RecursosPresentadorM4.OpenTD + RecursosPresentadorM4.OpenDivRow +
                RecursosPresentadorM4.OpenBotonInfo + theCompany.Id + //Boton Info 
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.BotonInvol + theCompany.Id + //Boton Contacto
                RecursosPresentadorM4.CloseBotonParametro + RecursosPresentadorM4.CloseDiv +
                RecursosPresentadorM4.CloseTD;
                _vista.Tabla.Text += RecursosPresentadorM4.CloseTR;
            }
        }
        #endregion
    }
}
