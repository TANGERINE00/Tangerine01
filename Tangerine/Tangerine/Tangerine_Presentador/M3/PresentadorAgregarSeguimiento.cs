using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M3;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M3
{
    public class PresentadorAgregarSeguimiento
    {
        IContratoAgregarSeguimiento vista;

        /// <summary>
        /// Constructor de la clase presentador
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorAgregarSeguimiento(IContratoAgregarSeguimiento vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo par cargar informacion en un como de tipo de registro de seguimiento
        /// </summary>
        public void CargarTipoDeSeguimiento()
        {
            vista.Tipo.Items.Insert(0, "Seleccione una opción");
            vista.Tipo.Items.Insert(1, "Llamada");
            vista.Tipo.Items.Insert(2, "Visita");
            vista.Tipo.DataBind();

        }

        /// <summary>
        /// Metodo para setear la fecha actual en la ue sera creada un registro de seguimiento
        /// </summary>
        public void MostrarFechaDeRegistro()
        {
            vista.Fecha = DateTime.Now.ToString();
        }

        /// <summary>
        /// Metodo que invoca al comando encargado de agrgar un nuevo registro de seguimiento
        /// </summary>
        public void Agregar(int idCliente)
        {
            
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearSeguimientoDeCliente(DateTime.Parse(vista.Fecha),
                vista.Opcion, vista.Motivo, idCliente);

            Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarSeguimiento(_entidad);
            comando.Ejecutar();
            
        }

    }
}
