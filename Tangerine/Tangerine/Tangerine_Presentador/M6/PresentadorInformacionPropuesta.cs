 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine;
using System.Web;
using System.Windows.Forms;

namespace Tangerine_Presentador.M6
{
    public class PresentadorInformacionPropuesta
    {
        IContratoInformacionPropuesta vistaInformacion;

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        /// <param name="vista">Vista con los metodos implementados de IContratoInformacionPropuesta</param>

        public PresentadorInformacionPropuesta(IContratoInformacionPropuesta vista)
        {
            this.vistaInformacion = vista;
        }

        /// <summary>
        /// Metodo que consulta una propuesta
        /// </summary>
        /// <param name="id"></param>

        public void consultarPropuesta(string id)
        {

            if (!id.Equals("0") || id != null)
            { 
            Entidad _propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(
                id, null, null, null, null, null, null, 0, DateTime.Now, DateTime.Now, 0, null);

            Comando<Entidad> cmdConsultar = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(_propuesta);

            _propuesta = cmdConsultar.Ejecutar();
           
            try
            {
                vistaInformacion.Codigo.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Nombre;

                imprimirStatus(_propuesta);

                imprimirCompania(_propuesta);

                vistaInformacion.Descripcion.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Descripcion;

                imprimirRequerimientos(_propuesta);

                imprimirDuracion(_propuesta);

                imprimirCosto(_propuesta);

                imprimirAcuerdo(_propuesta);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                MessageBox.Show(ex.Mensaje + ", por favor intente de nuevo.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                throw ex;
            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                MessageBox.Show(ex.Mensaje + ", por favor intente de nuevo.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", por favor intente de nuevo.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                throw ex;
            }
            }
        }
        /// <summary>
        /// Metodo que imprime en la vista la informacion de la compañia de esa propuesta
        /// </summary>
        /// <param name="_propuesta"></param>
        public void imprimirCompania(Entidad _propuesta)
        {
            Entidad _compania = DominioTangerine.Fabrica.FabricaEntidades.CrearEntidadCompaniaM4Llena(
                Int32.Parse(((DominioTangerine.Entidades.M6.Propuesta)_propuesta).IdCompañia), null, null, null, null, null,
                DateTime.Now, 0, 0, 0, 0);

            Comando<Entidad> cmdConsultarCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(_compania);

            _compania = cmdConsultarCompania.Ejecutar();

            vistaInformacion.Compania.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_compania).NombreCompania;
        }
        /// <summary>
        /// Metodo que imprime el status de esta propuesta
        /// </summary>
        /// <param name="_propuesta"></param>
        public void imprimirStatus(Entidad _propuesta)
        {
            if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Estatus == "Aprobado")
            {
                vistaInformacion.Status.Text = RecursosPresentadorPropuesta.aprobado;
            }
            else if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Estatus == "Cerrado")
            {
                vistaInformacion.Status.Text = RecursosPresentadorPropuesta.cerrado;
            }
            else if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Estatus == "Pendiente")
            {
                vistaInformacion.Status.Text = RecursosPresentadorPropuesta.pendiente;
            }
        }
        /// <summary>
        /// Metodo que imprime los requerimientos de esa propuesta
        /// </summary>
        /// <param name="_propuesta"></param>
        public void imprimirRequerimientos(Entidad _propuesta)
        {
                List<Entidad> _requerimientos;
                Comando<List<Entidad>> cmdConsultarRequerimientos = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarRequerimientoXPropuesta(_propuesta);

                _requerimientos = cmdConsultarRequerimientos.Ejecutar();

                foreach (Entidad _elRequerimiento in _requerimientos)
                {
                    vistaInformacion.Requerimientos.Text += 
                        ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).CodigoRequerimiento.ToString();

                    vistaInformacion.Requerimientos.Text += " - Descripción: "
                        + ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).Descripcion.ToString();

                    vistaInformacion.Requerimientos.Text += RecursosPresentadorPropuesta.Salto + RecursosPresentadorPropuesta.Salto;
            }
        }
        /// <summary>
        /// Metodo que imprime la duracion de esa propuesta
        /// </summary>
        /// <param name="_propuesta"></param>
        public void imprimirDuracion(Entidad _propuesta)
        {
            vistaInformacion.Duracion.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).CantDuracion
                    + " " + ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).TipoDuracion
                    + "  /  Fecha de inicio: " + ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Feincio.ToShortDateString()
                    + " - Fecha de terminación estimada: " 
                    + ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Fefinal.ToShortDateString();
        }

        public void imprimirCosto(Entidad _propuesta)
        {
            if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Moneda == "Bitcoin")
            {
                vistaInformacion.Costo.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Costo
                    + RecursosPresentadorPropuesta.bitcoin;
            }
            else if(((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Moneda == "Euro")
            {
                vistaInformacion.Costo.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Costo
                    + RecursosPresentadorPropuesta.euro;
            }
            else if(((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Moneda == "Dolar")
            {
                vistaInformacion.Costo.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Costo
                    + RecursosPresentadorPropuesta.dolar;
            }
            else if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Moneda == "Bolivar")
            {
                vistaInformacion.Costo.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Costo
                    + RecursosPresentadorPropuesta.bolivar;
            }
        }
        /// <summary>
        /// Metodo que imprime la forma de pago 
        /// </summary>
        /// <param name="_propuesta"></param>
        public void imprimirAcuerdo(Entidad _propuesta)
        {
            if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Acuerdopago == "Mensual")
            {
                vistaInformacion.AcuerdoPago.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Acuerdopago;
            }
            else if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Acuerdopago == "Por cuotas")
            {
                vistaInformacion.AcuerdoPago.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Entrega
                    + " cuotas"; 
            }
        }

    }
}
