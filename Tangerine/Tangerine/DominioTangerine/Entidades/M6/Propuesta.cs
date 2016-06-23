using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M6
{
    public class Propuesta : Entidad
    {
        #region Atributos

        /// <summary>
        /// Clase propuesta
        /// <attr name="_codigoP">Codigo unico indentificador de la propuesta</attr>
        /// <attr name="_nombre">nombre con el que se identificara a la propuesta</attr>
        /// <attr name="_descripcion">Descripcion breve sobre la propuesta</attr>
        /// <attr name="_tipoDuracion">duracion estimada de la propuesta {Meses, Dias, Horas}</attr>
        /// <attr name="_cantDuracion">cantidad de tiempo estimada de la propuesta</attr>
        /// <attr name="_acuerdopago">tipo de compromiso de pago al cual se va a llegar para la propuesta</attr>
        /// <attr name="_modalidadPago">modalidad de pago para la propuesta</attr>
        /// <attr name="_estatus">Estado en el que se encuentra la propuesta {Aprobada, Pendiente, Cerrada}</attr>
        /// <attr name="_moneda">Moneda base de pago para la propuesta de proyecto</attr>
        /// <attr name="_entrega">Dependiendo del compromiso de pago se llegara a una cantidad de entregas estipuladas </attr>
        /// <attr name="_feincio">fecha estimada de inicio </attr>
        /// <attr name="_fefinal">fecha estimada de fin </attr>
        /// <attr name="costo">Costo de realizacion del 100% del proyecto</attr>
        /// <attr name="_idCompañia">codigo de la  compañia de la  cual se puede generar una propuesta</attr> 
        /// <attr name="_listaRequerimiento">lista de requerimientos asociados a un proyecto</attr> 
        /// </summary>

        private String _codigoP;
        private String _nombre;
        private String _descripcion;
        private String _tipoDuracion;

        public String TipoDuracion
        {
            get { return _tipoDuracion; }
        }
        private String _cantDuracion;

        public String CantDuracion
        {
            get { return _cantDuracion; }
        }
        private String _acuerdopago;
        private String _estatus;
        private String _moneda;
        private int _entrega;
        private DateTime _feincio;
        private DateTime _fefinal;
        private int _costo;

        private String _idCompañia;

        private List<Requerimiento> _listaRequerimiento;


        #endregion

        #region Propiedades

        /// <summary>
        /// Get del codigo de la Propuesta
        /// </summary>

        public String CodigoP
        {
            get { return _codigoP; }
        }

        /// <summary>
        /// Get del nombre de la Propuesta
        /// </summary>
        public String Nombre
        {
            get { return _nombre; }
        }
        /// <summary>
        /// Get  de la descripcion de la Propuesta
        /// </summary>
        public String Descripcion
        {
            get { return _descripcion; }
        }
        /// <summary>
        /// Get  de la forma de pago de la Propuesta
        /// </summary>
        public String Acuerdopago
        {
            get { return _acuerdopago; }
         }
        /// <summary>
        /// Get  del estado de la Propuesta
        /// </summary>
        public String Estatus
        {
            get { return _estatus; }

        }
        /// <summary>
        /// Get  de la moneda de la Propuesta
        /// </summary>
        public String Moneda
        {
            get { return _moneda; }

        }
        /// <summary>
        /// Get  de la entrega de la Propuesta
        /// </summary>
        public int Entrega
        {
            get { return _entrega; }

        }
        /// <summary>
        /// Get  de la fecha de inicio de la Propuesta
        /// </summary>
        public DateTime Feincio
        {
            get { return _feincio; }

        }
        /// <summary>
        /// Get  de la fecha tope de la Propuesta
        /// </summary>
        public DateTime Fefinal
        {
            get { return _fefinal; }

        }
        /// <summary>
        /// Get  del costo de la Propuesta
        /// </summary>
        public int Costo
        {
            get { return _costo; }
        }

        /// <summary>
        /// Get  de la compañia asociada a la Propuesta
        /// </summary>
        public String IdCompañia
        {
            get { return _idCompañia; }
        }

        /// <summary>
        /// Get  de los requerimientos de la Propuesta
        /// </summary>
        public List<Requerimiento> ListaRequerimiento
        {
            get { return _listaRequerimiento; }
        }



        #endregion

        #region Constructor

        public Propuesta()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="_tipoDu"></param>
        /// <param name="duracion"></param>
        /// <param name="acuerdopago"></param>
        /// <param name="estatus"></param>
        /// <param name="moneda"></param>
        /// <param name="entrega"></param>
        /// <param name="feincio"></param>
        /// <param name="fefinal"></param>
        /// <param name="costo"></param>
        /// <param name="compañia"></param>

        public Propuesta(string nombre, string descripcion, string _tipoDu, string duracion, string acuerdopago, string estatus,
                         string moneda, int entrega, DateTime feincio, DateTime fefinal, int costo, string compañia)
        {
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._tipoDuracion = _tipoDu;
            this._cantDuracion = duracion;
            this._acuerdopago = acuerdopago;
            this._estatus = estatus;
            this._moneda = moneda;
            this._entrega = entrega;
            this._feincio = feincio;
            this._fefinal = fefinal;
            this._costo = costo;
            this._idCompañia = compañia;
        }

        /// <summary>
        /// Constructor Propuesta
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="_tipoDu"></param>
        /// <param name="duracion"></param>
        /// <param name="acuerdopago"></param>
        /// <param name="estatus"></param>
        /// <param name="moneda"></param>
        /// <param name="entrega"></param>
        /// <param name="feincio"></param>
        /// <param name="fefinal"></param>
        /// <param name="costo"></param>
        /// <param name="compañia"></param>

        public Propuesta(string codigo, string nombre, string descripcion, string _tipoDu, string duracion, string acuerdopago, string estatus,
                        string moneda, int entrega, DateTime feincio, DateTime fefinal, int costo, string compañia)
        {
            this._codigoP = codigo;
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._tipoDuracion = _tipoDu;
            this._cantDuracion = duracion;
            this._acuerdopago = acuerdopago;
            this._estatus = estatus;
            this._moneda = moneda;
            this._entrega = entrega;
            this._feincio = feincio;
            this._fefinal = fefinal;
            this._costo = costo;
            this._idCompañia = compañia;

        }
        /// <summary>
        /// Constructor Propuesta Requerimiento
        /// </summary>
        /// <param name="codigoP"></param>
        /// <param name="listaRequerimiento"></param>

    
        public Propuesta(string codigoP, List<Requerimiento> listaRequerimiento)
        {
            this._codigoP = codigoP;
            this._listaRequerimiento = listaRequerimiento;

        }

        #endregion

    }
}