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
                Entidad elRequerimiento = DominioTangerine.Fabrica.FabricaEntidades.ObtenerRequerimiento(vista.IdRequerimiento, vista.Concepto,
                    vista.IdPropuesta);
                    
                

             //Creación y Ejecución del Objeto Comando de Modificar Requerimiento, se le envia por parámetro el objeto Propuesta 'p'.
               Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarRequerimiento(elRequerimiento);
               comando.Ejecutar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de ejecucion, por favor realice el registro de nuevo.", "Error de pagina", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }


        }

        public void llenarDatosRequerimiento()
        {

            string debug = vista.IdRequerimiento;
            List<Entidad> _requerimientos;   
            Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(
                    vista.IdPropuesta, null, null, null, null, null, null, 0, DateTime.Now, DateTime.Now, 0, null);


     

            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarRequerimientoXPropuesta(propuesta);

               try
               {
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
               catch (Exception e)
               {
                   MessageBox.Show("Error carga de datos, por favor realice el registro de nuevo.", "Error de pagina", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
               }
           
                
        
        }
 

        public void llenarVista()
        {
            llenarDatosRequerimiento();
        }
    
    }
}
