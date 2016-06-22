﻿using System;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public override Boolean Ejecutar()
        {
            IDAOPago Pago = FabricaDAOSqlServer.CrearDAOPago();
            return Pago.Agregar(this._laEntidad);
            

        }
    
    }
}
