using DatosTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine;
using DominioTangerine.Entidades.M6;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Windows.Forms;


namespace Tangerine_Presentador.M6
{
    public class PresentadorModificarRequerimiento
    {
        IContratoModificarRequerimiento vista;

        #region Atributos
        string _idRequerimiento = String.Empty;
        string _concepto = String.Empty;
        #endregion

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        /// <param name="vista">Vista con los metodos implementados de IContratoModificarRequerimiento</param>
        public PresentadorModificarRequerimiento(IContratoModificarRequerimiento vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo que agrega los nuevos requerimientos
        /// </summary>
        public void ModificarRequerimiento()
        {
            try
            {
                Entidad elRequerimiento = DominioTangerine.Fabrica.FabricaEntidades.ObtenerRequerimiento(vista.IdRequerimiento, vista.Concepto,
                    vista.IdPropuesta);
                    
                

             //Creación y Ejecución del Objeto Comando de Modificar Requerimiento, se le envia por parámetro el objeto Propuesta 'p'.
               Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarRequerimiento(elRequerimiento);
               comando.Ejecutar();
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

        /// <summary>
        /// Metodo que llena los campos de la vista con los datos del requerimiento
        /// </summary>
        public void llenarDatosRequerimiento()
        {

            string debug = vista.IdRequerimiento;
            List<Entidad> _requerimientos;   
            Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(
                    vista.IdPropuesta, null, null, null, null, null, null, 0, DateTime.Now, DateTime.Now, 0, null);

            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarRequerimientoXPropuesta(propuesta);
                   _requerimientos = comando.Ejecutar();

                   foreach (Entidad _elRequerimiento in _requerimientos)
                   {
                       if (vista.IdRequerimiento.Equals(((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).CodigoRequerimiento.ToString()))
                      {
                          vista.Concepto = ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).Descripcion.ToString();
                          vista.IdRequerimiento = ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).CodigoRequerimiento.ToString();
                      }
                   }    
        
        }

        /// <summary>
        /// Metodo inicial para la carga de los datos del requerimiento.
        /// </summary>
        public void llenarVista()
        {
            try
            {
                llenarDatosRequerimiento();
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
}
