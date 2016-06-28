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
    public class PresentadorModificarClientePotencial
    {
        IContratoModificarClientePotencial vista;

        /// <summary>
        /// Constructor d la clase presentador 
        /// </summary>
        /// <param name="vista"></param>
        /// <returns></returns>
        public PresentadorModificarClientePotencial(IContratoModificarClientePotencial vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para instanciar y ejecutar el comando para modificar un cliente potencial
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public void Llenar(int idCliente)
        {
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.ObtenerClientePotencial();
            _entidad.Id = idCliente;

            Comando<Entidad> comando = 
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarClientePotencial(_entidad);
            Entidad elClientePotencial = comando.Ejecutar();
            try
            {
                DominioTangerine.Entidades.M3.ClientePotencial elCliente = 
                    (DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial;

                vista.NombreEtiqueta = elCliente.NombreClientePotencial;
                vista.RifEtiqueta = elCliente.RifClientePotencial;
                vista.CorreoElectronico = elCliente.EmailClientePotencial;
                vista.PresupuestoInversion = elCliente.PresupuestoAnual_inversion;
                vista.NumeroLlamadas = elCliente.NumeroLlamadas;
                vista.NumeroVisitas = elCliente.NumeroVisitas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que instancia y ejecuta el comando para modificar datos del cliente
        /// </summary>
        /// <param name="idCliente"></param>
        public void ModificarClientePotencial(int idCliente)
        {
            bool modificable = true;

            Entidad _entidad = 
                DominioTangerine.Fabrica.FabricaEntidades.CrearClientePotencial(idCliente,
                                                                                    vista.NombreEtiqueta,
                                                                                    vista.RifEtiqueta,
                                                                                    vista.CorreoElectronico,
                                                                                    vista.PresupuestoInversion, 
                                                                                    vista.NumeroLlamadas,
                                                                                    vista.NumeroVisitas);
            Comando<bool> comando = 
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoModificarClientePotencial(_entidad);

            modificable = VerificarDatosDeCliente(vista.NombreEtiqueta, vista.CorreoElectronico, vista.RifEtiqueta, idCliente);

            if (modificable)
                vista.AccionSobreBd = comando.Ejecutar() ? true : false;
            else
                vista.AccionSobreBd = false;
        }

        /// <summary>
        /// Método que verifica la existencia del cliente
        /// </summary>
        /// <returns>bool</returns>
        private bool VerificarDatosDeCliente(String nombre, String correo, String rif, int idNuevoCliente)
        {
            bool seAgrega = true;
            Comando<List<Entidad>> comando =
                    LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosClientePotencial();
            List<Entidad> list = comando.Ejecutar();

            foreach (Entidad item in list)
            {
                DominioTangerine.Entidades.M3.ClientePotencial cliente = (DominioTangerine.Entidades.M3.ClientePotencial)item;
                if (cliente.IdClientePotencial != idNuevoCliente)
                {
                    if (cliente.NombreClientePotencial.Equals(nombre))
                        seAgrega = false;

                    if (cliente.RifClientePotencial.Equals(rif))
                        seAgrega = false;

                    if (cliente.EmailClientePotencial.Equals(correo))
                        seAgrega = false;

                    if (!seAgrega)
                        break;
                }

                

            }

            return seAgrega;
        }


    }
}
