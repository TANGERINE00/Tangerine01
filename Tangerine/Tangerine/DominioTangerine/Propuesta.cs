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

        private List<Requerimiento> _listaRequerimiento;
        private string conNombre;
        private int conEstatus;
        private int p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;
        private string p6;
        private string p7;
        private string p8;
        private string p9;
        private string p10;
        private string p11;
        private int p12;
        private string p13;
        private string p14;
        private int p15;
        private DateTime dateTime1;
        private DateTime dateTime2;
        private string conDescripcion;
        private string contipoDuracion1;
        private string contipoDuracion2;
        private string conAcuerdo;
        private string conEstatus1;
        private string conMoneda;
        private int conEntregas;
        private DateTime conFechaIni;
        private DateTime conFechaFin;
        private int conCosto;
        private int conFkComp;
        private string contipoDuracion;



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

        public Propuesta( string nombre, string descripcion, string _tipoDu, string duracion, string acuerdopago, string estatus,
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

        //constructor para M7
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

        public Propuesta(string codigoP, List<Requerimiento> listaRequerimiento)
        {
            this._codigoP = codigoP;
            this._listaRequerimiento = listaRequerimiento;

        }

       

        public Propuesta(string p3, string p4, string p5, string p6, string p7, string p8, int p12, DateTime dateTime1, DateTime dateTime2, int p15)
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
        }

        //public Propuesta(string conNombre, string conDescripcion, string contipoDuracion, string conAcuerdo, string conEstatus1, string conMoneda, int conEntregas, DateTime conFechaIni, DateTime conFechaFin, int conCosto, int conFkComp)
        //{
        //    // TODO: Complete member initialization
        //    this.conNombre = conNombre;
        //    this.conDescripcion = conDescripcion;
        //    this.contipoDuracion = contipoDuracion;
        //    this.conAcuerdo = conAcuerdo;
        //    this.conEstatus1 = conEstatus1;
        //    this.conMoneda = conMoneda;
        //    this.conEntregas = conEntregas;
        //    this.conFechaIni = conFechaIni;
        //    this.conFechaFin = conFechaFin;
        //    this.conCosto = conCosto;
        //    this.conFkComp = conFkComp;
        //}

       

       

      

        





        #endregion


    }
}
