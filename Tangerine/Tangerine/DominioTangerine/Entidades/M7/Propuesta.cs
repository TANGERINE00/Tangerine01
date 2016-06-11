using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M7
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
            set { _tipoDuracion = value; }
        }
        private String _cantDuracion;

        public String CantDuracion
        {
            get { return _cantDuracion; }
            set { _cantDuracion = value; }
        }
        private String _acuerdopago;
        private String _estatus;
        private String _moneda;
        private int _entrega;
        private DateTime _feincio;
        private DateTime _fefinal;
        private int _costo;
        private String _idCompañia;
        private List<Entidad> _listaRequerimiento;


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

        public String IdCompañia
        {
            get { return _idCompañia; }
            set { _idCompañia = value; }
        }


        public List<Entidad> ListaRequerimiento
        {
            get { return _listaRequerimiento; }
            set { _listaRequerimiento = value; }
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
        /// Constructos metodo PropuestaProyecto disenado para el Modulo_7
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

        public Propuesta(string codigoP, List<Entidad> listaRequerimiento)
        {
            this._codigoP = codigoP;
            this._listaRequerimiento = listaRequerimiento;
        }



        public Propuesta(string p3, string p4, string p5, string p6, string p7, string p8, int p12, DateTime dateTime1, DateTime dateTime2, int p15, string fkcompa)
        {
            // TODO: Complete member initialization

            this._descripcion = p3;
            this._cantDuracion = p4;
            this._tipoDuracion = p5;
            this._acuerdopago = p6;
            this._estatus = p7;
            this._moneda = p8;
            this._entrega = p12;
            this._feincio = dateTime1;
            this._fefinal = dateTime2;
            this._costo = p15;
            this._idCompañia = fkcompa;
        }



        #endregion
    }
}
