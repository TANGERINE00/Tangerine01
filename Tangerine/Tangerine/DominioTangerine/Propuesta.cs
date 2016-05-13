using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Propuesta
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

        private String _codigoP;
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

        private Compania _nombrCompañia;

        private List<Requerimiento> _listaRequerimiento;

       

        #endregion

        #region Propiedades

        public String CodigoP
        {
            get { return _codigoP; }
            set { _codigoP = value; }
        }
        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public String Duracion
        {
            get { return _duracion; }
            set { _duracion = value; }
        }
        public String Acuerdopago
        {
            get { return _acuerdopago; }
            set { _acuerdopago = value; }
        }
        public String Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        public String Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }
        public int Entrega
        {
            get { return _entrega; }
            set { _entrega = value; }
        }
        public DateTime Feincio
        {
            get { return _feincio; }
            set { _feincio = value; }
        }
        public DateTime Fefinal
        {
            get { return _fefinal; }
            set { _fefinal = value; }
        }
        public int Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }
        public Compania NombrCompañia
        {
            get { return _nombrCompañia; }
            set { _nombrCompañia = value; }
        }

        public List<Requerimiento> ListaRequerimiento
        {
            get { return _listaRequerimiento; }
            set { _listaRequerimiento = value; }
        }
      


        #endregion

        #region Constructor

        public Propuesta()
        {

        }

        public Propuesta(String codigoP, String nombre, String descripcion, String duracion, String acuerdopago, String estatus,
                         String moneda, int entrega, DateTime feincio, DateTime fefinal, int costo, Compania lacompañia,
                         List<Requerimiento> listaRequerimiento)
        {
            this._codigoP = codigoP;
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._duracion = duracion;
            this._acuerdopago = acuerdopago;
            this._estatus = estatus;
            this._moneda = moneda;
            this._entrega = entrega;
            this._feincio = feincio;
            this._fefinal = fefinal;
            this._costo = costo;
            this._nombrCompañia = lacompañia;
            this._listaRequerimiento = listaRequerimiento;

        }

        #endregion

    }
}
