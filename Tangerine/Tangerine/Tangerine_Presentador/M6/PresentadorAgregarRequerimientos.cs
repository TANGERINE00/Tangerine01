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
using System.Windows.Forms;

namespace Tangerine_Presentador.M6
{
    // Este método agrega tanto Propuestas como sus requerimientos asociados.
    public class PresentadorAgregarRequerimientos
    {
        #region Atributos
        IContratoAgregarRequerimientos vista;
        Boolean Confirmacion;
        string _nombcodigoPropuesta = String.Empty;
        string _idCompañia = String.Empty;
        DateTime today = DateTime.Now;
        String[] _precondicion;
        #endregion

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorAgregarRequerimientos(IContratoAgregarRequerimientos vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo encargado de agregar el requerimiento
        /// </summary>

        public void AgregarRequerimientos()
        {
            _nombcodigoPropuesta = vista.IdPropuesta;

            try
            {
                //El atributo _precondicion recibe un arreglo de strings. ArrPrecondicion es un String que contiene todos los requerimientos
                //agregados en la vista separados por un ';'.
                _precondicion = vista.ArrPrecondicion.Split(';');

                //Se recorre el arreglo.
                for (int i = 0; i < _precondicion.Length - 1; i++)
                {
                    int j = i + 1;
                    string codReq = "RF_" + today.ToString("yyMMddhhmmss") + j.ToString();

                    //Creación del Objeto Propuesta.
                    Entidad requerimiento = DominioTangerine.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                        codReq, _precondicion[i].ToString(), _nombcodigoPropuesta);

                    //Creación y Ejecución del Objeto Comando de Agregar Propuesta, se le envia por parámetro el objeto requerimiento.
                    Comando<bool> comando2 = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(requerimiento);
                    comando2.Ejecutar();
                }
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
