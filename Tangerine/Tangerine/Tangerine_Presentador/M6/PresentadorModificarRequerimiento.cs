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

        public PresentadorModificarRequerimiento(IContratoModificarRequerimiento vista)
        {
            this.vista = vista;
        }

        public void ModificarRequerimiento()
        {
            try
            {
             //   DominioTangerine.Entidades.M6.Requerimiento elRequerimiento = new DominioTangerine.Entidades.M6.Requerimiento(idRequerimiento, descripcion, idPropuesta);

                //  elRequerimiento.Id = int.Parse(idRequerimiento);

                //Creación y Ejecución del Objeto Comando de Modificar Requerimiento, se le envia por parámetro el objeto Propuesta 'p'.
              //  Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarRequerimiento(elRequerimiento);
       //         comando.Ejecutar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de ejecucion, por favor realice el registro de nuevo.", "Error de pagina", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }


        }

        public void llenarDatosRequerimiento()
        {

         //   vista.Descripcion = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Descripcion;

          //   vista.ComboDuracion = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).TipoDuracion;
           
        }
 

        public void llenarVista()
        {
            llenarDatosRequerimiento();
        }
    
    }
}
