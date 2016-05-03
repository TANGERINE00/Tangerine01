using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    class Propuesta
    {
        #region Atributos

        /// <summary>
        /// Clase propuesta
        /// <attr name="codigo">Codigo unico indentificador de la propuesta</attr>
        /// <attr name="nombre">Nombre del proyecto</attr>
        /// <attr name="estatus">Estado en el que se encuentra la propuesta {Aprobada, Pendiente, Cerrada}</attr>
        /// <attr name="descripcion">Descripcion breve sobre la propuesta</attr>
        /// <attr name="moneda">Moneda base de pago para la propuesta de proyecto</attr>
        /// <attr name="costo">Costo de realizacion del 100% del proyecto</attr>
        /// </summary>

        private String codigo;
        private String nombre;
        private List<Compania> listaCompania;
        private String descripcion;
        private String moneda;
        private int costo;

        #endregion

      
    }
}
