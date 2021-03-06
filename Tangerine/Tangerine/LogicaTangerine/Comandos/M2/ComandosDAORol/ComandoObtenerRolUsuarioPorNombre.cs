﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M2;
using DatosTangerine.Fabrica;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M2;

namespace LogicaTangerine.Comandos.M2.ComandosDAORol
{
    class ComandoObtenerRolUsuarioPorNombre : Comando<DominioTangerine.Entidad>
    {
        
        public string _nombreoRol;

        /// <summary>
        /// Constructor que recibe un parametro nombre rol
        /// </summary>
        /// <param name="nombreRol">Nombre del rol a usar</param>
        public ComandoObtenerRolUsuarioPorNombre( string nombreRol )
        {
            _nombreoRol = nombreRol;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoRol y usar el método Obtener Rol Usuario por nombre
        /// </summary>
        /// <returns>Retorna una instancia del tipo Entidad</returns>
        public override DominioTangerine.Entidad Ejecutar()
        {
            try
            {
                DominioTangerine.Entidad resultado;
                IDAORol rolDAO = FabricaDAOSqlServer.crearDaoRol();
                resultado = rolDAO.ObtenerRolUsuarioPorNombre( _nombreoRol );
                return resultado;
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "DS-202" , "Metodo no implementado" , ex );
            }

        }
    }
}
