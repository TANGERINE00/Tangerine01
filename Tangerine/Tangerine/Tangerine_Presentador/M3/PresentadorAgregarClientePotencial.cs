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
    public class PresentadorAgregarClientePotencial
    {
        IContratoAgregarClientePotencial vista;

        /// <summary>
        /// Constructor d la clase presentador 
        /// </summary>
        /// <param name="vista"></param>
        /// <returns></returns>
        public PresentadorAgregarClientePotencial(IContratoAgregarClientePotencial vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método que instancia y ejecuta al comando para agregar un cliente potencial
        /// </summary>
        /// <returns></returns>
        public void Agregar()
        {
            bool siAgrega;
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearClientePotencial(vista.NombreEtiqueta,
                                                                                              vista.RifEtiqueta, vista.CorreoElectronico,
                                                                                              vista.PresupuestoInversion,1);

            Comando<bool> comandoAgregar = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(_entidad);

            siAgrega = VerificarDatosDeCliente(vista.NombreEtiqueta, vista.CorreoElectronico, vista.RifEtiqueta);
            if (siAgrega)
                vista.AccionSobreBd = comandoAgregar.Ejecutar() ? true : false;
            else
                vista.AccionSobreBd= false;
        }

        /// <summary>
        /// Método que verifica la existencia del cliente
        /// </summary>
        /// <returns>bool</returns>
        private bool VerificarDatosDeCliente(String nombre, String correo, String rif)
        {
            bool seAgrega = true;
            Comando<List<Entidad>> comando =
                    LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosClientePotencial();
            List<Entidad> list = comando.Ejecutar();

            foreach (Entidad item in list)
            {
                DominioTangerine.Entidades.M3.ClientePotencial cliente = (DominioTangerine.Entidades.M3.ClientePotencial)item;

                if (cliente.NombreClientePotencial.Equals(nombre))
                    seAgrega = false;

                if (cliente.RifClientePotencial.Equals(rif))
                    seAgrega = false;

                if (cliente.EmailClientePotencial.Equals(correo))
                    seAgrega = false;

                if (!seAgrega)
                    break;
                
            }

            return seAgrega;
        }

    }
}
