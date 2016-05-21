using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DominioTangerine
{
    public class Proyecto
    {
        #region Atributos
        private int _idproyecto;
        private string _nombre;
        private string _codigo;
        private DateTime _fechainicio;
        private DateTime _fechaestimadafin;
        private double _costo;
        private string _descripcion;
        private string _realizacion;
        private string _estatus;
        private string _razon;
        private string _acuerdopago;
        private int _idpropuesta;
        private int _idcompania;
        private int _idgerente;
        private  List<Empleado> _empleados ;
        private List <Contacto> _contacto;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase.
        /// </summary>
        public Proyecto()
        {

        }

        /// <summary>
        /// Constructor con los atributos.
        /// </summary>
        /// <param name="id_proyecto"></param>
        /// <param name="nombre"></param>
        /// <param name="codigo"></param>
        /// <param name="fecha_inicio"></param>
        /// <param name="fecha_estimada_fin"></param>
        /// <param name="costo"></param>
        /// <param name="realizacion"></param>
        /// <param name="estatus"></param>
        /// <param name="razon"></param>
        /// <param name="acuerdopago"></param>
        /// <param name="id_propuesta"></param>
        /// <param name="id_responsable"></param>
        /// <param name="id_gerente"></param>

        public Proyecto(int id_proyecto,string nombre,string codigo,DateTime fecha_inicio,DateTime fecha_estimada_fin,
                 double costo,string descripcion, string realizacion,string estatus,string razon,string acuerdopago,int id_propuesta,int id_responsable,
                 int id_gerente )
        {
            this._idproyecto = id_proyecto;
            this._nombre = nombre;
            this._codigo = codigo;
            this._fechainicio = fecha_inicio;
            this._fechaestimadafin = fecha_estimada_fin;
            this._costo = costo;
            this._descripcion = descripcion;
            this._realizacion = realizacion;
            this._estatus = estatus;
            this._razon = razon;
            this._acuerdopago = acuerdopago;
            this._idpropuesta = id_propuesta;
            this._idcompania = id_responsable;
            this._idgerente = id_gerente;
        }


        #endregion

        #region Get's Set's

        /// <summary>
        /// Metodo para setear y obtener el ID del proyecto
        /// </summary>
        /// <returns>Retorna el id del proyecto</returns>
        public int Idproyecto
        {
            get { return _idproyecto; }
            set { _idproyecto = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el nombre del proyecto
        /// </summary>
        /// <returns>Retorna el nombre del proyecto</returns>
        
        
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el codigo del proyecto
        /// </summary>
        /// <returns>Retorna el codigo del proyecto</returns>
        
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener la fecha de inicio del proyecto
        /// </summary>
        /// <returns>Retorna la fecha de inicio del proyecto</returns>
        
        public DateTime Fechainicio
        {
            get { return _fechainicio; }
            set { _fechainicio = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener la fecha estimada de fin del proyecto
        /// </summary>
        /// <returns>Retorna la fecha estimada de fin del proyecto</returns>
        

        public DateTime Fechaestimadafin
        {
            get { return _fechaestimadafin; }
            set { _fechaestimadafin = value; }
        }


        /// <summary>
        /// Metodo para setear y obtener el costo del proyecto
        /// </summary>
        /// <returns>Retorna el costo del proyecto</returns>
        

        public double Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener la descripcion del proyecto
        /// </summary>
        /// <returns>Retorna la descripcion del proyecto</returns>
        

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }


        /// <summary>
        /// Metodo para setear y obtener la realizacion del proyecto
        /// </summary>
        /// <returns>Retorna la realizacion del proyecto</returns>
        
        public string Realizacion
        {
            get { return _realizacion; }
            set { _realizacion = value; }
        }


        /// <summary>
        /// Metodo para setear y obtener el estatus del proyecto
        /// </summary>
        /// <returns>Retorna el estatus del proyecto</returns>

        public string Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener la razon de cancelacion del proyecto
        /// </summary>
        /// <returns>Retorna la razon de cancelacion del proyecto</returns>


        public string Razon
        {
            get { return _razon; }
            set { _razon = value; }
        }


        /// <summary>
        /// Metodo para setear y obtener el acuerdo de pago del proyecto
        /// </summary>
        /// <returns>Retorna el id de la propuesta del proyecto</returns>


        public string Acuerdopago
        {
            get { return _acuerdopago; }
            set { _acuerdopago = value; }
        }


        /// <summary>
        /// Metodo para setear y obtener el id de la propuesta del proyecto
        /// </summary>
        /// <returns>Retorna el id de la propuesta del proyecto</returns>

        public int Idpropuesta
        {
            get { return _idpropuesta; }
            set { _idpropuesta = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el id del responsable del proyecto
        /// </summary>
        /// <returns>Retorna el id del responsable del proyecto</returns>


        public int Idresponsable
        {
            get { return _idcompania; }
            set { _idcompania = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el id del gerente del proyecto
        /// </summary>
        /// <returns>Retorna el id del gerente del proyecto</returns>


        public int Idgerente
        {
            get { return _idgerente; }
            set { _idgerente = value; }
        }

        public int Idcompania
        {
            get { return _idcompania; }
            set { _idcompania = value; }
        }

       /// <summary>
       /// Metodo que devuelve la lista de empleados
       /// </summary>
       /// <returns>Lista de empleados</returns>
        public List<Empleado> get_empleados ()
        {
             return _empleados;  
         
        }

        /// <summary>
        /// medtodo que define la lista de empleado
        /// </summary>
        /// <param name="e"></param>
        public void set_empleados ( List<Empleado> e ) {
           
            _empleados =  e;
            
        }

        /// <summary>
        /// Metodo que devuelve la lista de empleados
        /// </summary>
        /// <returns>Lista de empleados</returns>
        public List<Contacto> get__contactos()
        {
            return _contacto;

        }

        /// <summary>
        /// medtodo que define la lista de contacto
        /// </summary>
        /// <param name="e"></param>
        public void set_contactos(List<Contacto> e)
        {

            _contacto = e;

        }
        
        
        #endregion
    }
}