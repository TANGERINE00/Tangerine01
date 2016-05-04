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
        /// <attr name="_codigo">Codigo unico indentificador de la propuesta</attr>
        /// <attr name="_nombre">nombre con el que se identificara a la propuesta</attr>
        /// <attr name="_descripcion">Descripcion breve sobre la propuesta</attr>
        /// <attr name="_duracion">duracion estimada de la propuesta {Meses, Dias, Horas}</attr>
        /// <attr name="_acuerdopago">tipo de compromiso de pago al cual se va a llegar para la propuesta</attr>
        /// <attr name="_estatus">Estado en el que se encuentra la propuesta {Aprobada, Pendiente, Cerrada}</attr>
        /// <attr name="_moneda">Moneda base de pago para la propuesta de proyecto</attr>
        /// <attr name="_entrega">Dependiendo del compromiso de pago se llegara a una cantidad de entregas estipuladas </attr>
        /// <attr name="_feincio">fecha estimada de inicio </attr>
        /// <attr name="_fefinal">fecha estimada de fin </attr>
        /// <attr name="costo">Costo de realizacion del 100% del proyecto</attr>
        /// <attr name="_listaCompania">lista de las compañias de las cuales se puede generar una propuesta</attr> 
        /// <attr name="_listaRequerimiento">lista de requerimientos asociados a un proyecto</attr> 
        /// </summary>

        private String _codigo;
        private String _nombre;
        private String _descripcion;
        private String _duracion;
        private String _acuerdopago;
        private String _estatus;
        private String _moneda;
        private int _entrega;
        private DateTime _feincio;
        private DateTime _fefinal;
        private int _costo;

        private List<Compania> _listaCompania;
        private List<Requerimiento> _listaRequerimiento;

        #endregion

        #region Constructor

        public Propuesta()
        {

        }

        #endregion



    }
}
