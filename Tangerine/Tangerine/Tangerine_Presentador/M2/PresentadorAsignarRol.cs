using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M2;

namespace Tangerine_Presentador.M2
{
    public class PresentadorAsignarRol
    {
        private int _numFicha;
        private IContratoAsignarRol _vista;

        /// <summary>
        /// Constructor que recibe la vista de AsignarRol y el numero de ficha del usuario en cuestión
        /// </summary>
        /// <param name="vista"></param>
        /// <param name="numFicha"></param>
        public PresentadorAsignarRol ( IContratoAsignarRol vista, int numFicha )
        {
            _vista = vista;
            _numFicha = numFicha;
        }

        /// <summary>
        /// Inicio de vista de la página de Asignar Rol
        /// </summary>
        public void inicioVista()
        {
            LogicaTangerine.Comando<DominioTangerine.Entidad> theComando = LogicaTangerine.Fabrica.FabricaComandos.obtenerUsuario(_numFicha);
            LogicaTangerine.Comandos.M2.ComandoObtenerUsuario comando = (LogicaTangerine.Comandos.M2.ComandoObtenerUsuario)theComando;
            DominioTangerine.Entidad theUser = comando.Ejecutar();
            DominioTangerine.Entidades.M2.UsuarioM2 user = (DominioTangerine.Entidades.M2.UsuarioM2)theUser;
            _vista.usuario = user.nombreUsuario;
            _vista.comboBoxRol = user.rol.nombre;
        }

        /// <summary>
        /// Asigna un nuevo rol al usuario en cuestión
        /// </summary>
        public void asignar()
        {
            /*LogicaTangerine.Comando<Boolean> theComando = LogicaTangerine.Fabrica.FabricaComandos.obtenerComandoModificarRolUsuario();
            LogicaModificarRol.ModificarRol(_vista.usuario, _vista.comboBoxRol);*/
        }
    }
}
