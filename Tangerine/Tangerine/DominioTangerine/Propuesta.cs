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
        /// <attr name="nombre">nombre con el que se identificara a la propuesta</attr>
        /// <attr name="descripcion">Descripcion breve sobre la propuesta</attr>
        /// <attr name="duracion">duracion estimada de la propuesta {Meses, Dias, Horas}</attr>
       
        
        /// <attr name="moneda">Moneda base de pago para la propuesta de proyecto</attr>
        /// <attr name="costo">Costo de realizacion del 100% del proyecto</attr>
        /// <attr name="estatus">Estado en el que se encuentra la propuesta {Aprobada, Pendiente, Cerrada}</attr>
        /// </summary>

        private String _codigo;
        private String _nombre;
        private String _descripcion;
        private String _duracion;
        private String _acuerdopago;
        private String _estatus;
        private int _entrega;
        private DateTime _feincio;
        private DateTime _fefinal;
        private String _moneda;
        private int _costo;

        private List<Compania> _listaCompania;
        private List<Requerimiento> _listaRequerimiento;
      
        #endregion

      
    }
}
