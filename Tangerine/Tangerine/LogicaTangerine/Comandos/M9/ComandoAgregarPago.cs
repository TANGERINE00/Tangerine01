using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M9;
using DatosTangerine.InterfazDAO.M9;
using DatosTangerine.Fabrica;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M9
{
    public class ComandoAgregarPago : Comando<Boolean>
    {


        public ComandoAgregarPago (Entidad entidad)
        {
            this._laEntidad = entidad;
        }
        /// <summary>
        /// Método para crear la instancia de la clase DaoPago y agregar el pago
        /// </summary>
        /// <returns></returns>
        public override Boolean Ejecutar()
        {
            IDAOPago Pago = FabricaDAOSqlServer.CrearDAOPago();
<<<<<<< HEAD
            Pago.Agregar(this._laEntidad);
            return true;
=======
            return Pago.Agregar(this._laEntidad);
            
>>>>>>> 27744b3a4a27d67c70e9e29bb58b3fb719a7b234

        }
    
    }
}
