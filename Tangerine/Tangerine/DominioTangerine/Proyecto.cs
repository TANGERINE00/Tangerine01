using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private double _realizacion;
        private string _estatus;
        private string _razon;
        private int _idpropuesta;
        private int _idresponsable;
        private int _idgerente;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase.
        /// </summary>
        Proyecto()
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
        /// <param name="id_propuesta"></param>
        /// <param name="id_responsable"></param>
        /// <param name="id_gerente"></param>

        Proyecto(int id_proyecto,string nombre,string codigo,DateTime fecha_inicio,DateTime fecha_estimada_fin,
                  double costo,double realizacion,string estatus,string razon,int id_propuesta,int id_responsable,
                 int id_gerente)
        {
            this._idproyecto = id_proyecto;
            this._nombre = nombre;
            this._codigo = codigo;
            this._fechainicio = fecha_inicio;
            this._fechaestimadafin = fecha_estimada_fin;
            this._costo = costo;
            this._realizacion = realizacion;
            this._estatus = estatus;
            this._razon = razon;
            this._idpropuesta = id_propuesta;
            this._idresponsable = id_responsable;
            this._idgerente = id_gerente;
        }


        #endregion

        #region Get's Set's


        /// <summary>
        /// Metodo para obtener el ID del proyecto
        /// </summary>
        /// <returns>Retorna el numero del proyecto</returns>
        public int getId_Proyecto()
        {
            return this._idproyecto;
        }

        /// <summary>
        /// Metodo para setear el ID del proyecto
        /// </summary>
        /// <param name="id_proyecto"></param>
       
        public void setId_Proyecto(int id_proyecto)
        {
            this._idproyecto = id_proyecto;
        }


        /// <summary>
        /// Metodo para obtener el nombre del proyecto
        /// </summary>
        /// <returns>Retorna el nombre del proyecto</returns>
        public string getNombre()
        {
            return this._nombre;
        }


        /// <summary>
        /// Metodo para setear el nombre del proyecto
        /// </summary>
        /// <param name="Nombre"></param>
        public void setNombre(string Nombre)
        {
            this._nombre = Nombre;
        }

        /// <summary>
        /// Metodo para obtener el codigo del proyecto
        /// </summary>
        /// <returns>Retorna el codigo del proyecto</returns>
        public string getCodigo()
        {
            return this._codigo;
        }


        /// <summary>
        /// Metodo para setear el codigo del proyecto
        /// </summary>
        /// <param name="Codigo"></param>
        public void setCodigo(string Codigo)
        {
            this._codigo = Codigo;
        }


        /// <summary>
        /// Metodo para obtener la fecha de inicio del proyecto
        /// </summary>
        /// <returns>Retorna la fecha de inicio del proyecto</returns>
        public DateTime getFecha_inicio()
        {
            return this._fechainicio;
        }



        /// <summary>
        /// Metodo para setear la fecha de inicio del proyecto
        /// </summary>
        /// <param name="Fecha_inicio"></param>
        public void setFecha_inicio(DateTime Fecha_inicio)
        {
            this._fechainicio = Fecha_inicio;
        }


        /// <summary>
        /// Metodo para obtener la fecha estimada para el fin del proyecto
        /// </summary>
        /// <returns>Retorna la fecha estimada para el fin del proyecto</returns>
        public DateTime getFecha_estimada_fin()
        {
            return this._fechaestimadafin;
        }


        /// <summary>
        /// Metodo para setear la fecha estimada de fin para el proyecto
        /// </summary>
        /// <param name="fecha_estimada_fin"></param>
        public void setFecha_estimada_fin(DateTime fecha_estimada_fin)
        {
            this._fechaestimadafin = fecha_estimada_fin;
        }

        /// <summary>
        /// Metodo para obtener el costo del proyecto
        /// </summary>
        /// <returns>Retorna el costo del proyecto</returns>
        public double getCosto()
        {
            return this._costo;
        }

        /// <summary>
        /// Metodo para setear el costo del proyecto
        /// </summary>
        /// <param name="costo"></param>
        public void setCosto(double costo)
        {
            this._costo = costo;
        }

        /// <summary>
        /// Metodo para obtener el porcentaje de realizacion del proyecto
        /// </summary>
        /// <returns>Retorna el porcentje de realizacion proyecto</returns>
        public double getRealizacion()
        {
            return this._realizacion;
        }

        /// <summary>
        /// Metodo para setear porcentaje de realizacion del proyecto
        /// </summary>
        /// <param name="realizacion"></param>
        public void setRealizacion(double realizacion)
        {
            this._realizacion = realizacion;
        }


        /// <summary>
        /// Metodo para obtener el estatus del proyecto
        /// </summary>
        /// <returns>Retorna el estatus del proyecto</returns>
        public string getEstatus()
        {
            return this._estatus;
        }

        /// <summary>
        /// Metodo para setear el estatus del proyecto
        /// </summary>
        /// <param name="estatus"></param>
        public void setEstatus(string estatus)
        {
            this._estatus = estatus;
        }


        /// <summary>
        /// Metodo para obtener la razon para la cancelacion del proyecto
        /// </summary>
        /// <returns>Retorna la razon para la cancelacion del proyecto</returns>
        public string getRazon()
        {
            return this._razon;
        }


        /// <summary>
        /// Metodo para setear la razon para la cancelacion del proyecto
        /// </summary>
        /// <param name="razon"></param>
        public void setRazon(string razon)
        {
            this._razon = razon;
        }

        /// <summary>
        /// Metodo para obtener el ID de la propuesta del proyecto
        /// </summary>
        /// <returns>Retorna el ID de la propuesta del proyecto</returns>
        public int getId_Propuesta()
        {
            return this._idpropuesta;
        }


        /// <summary>
        /// Metodo para setear el ID de la propuesta del proyecto
        /// </summary>
        /// <param name="id_propuesta"></param>
        public void setId_Propuesta(int id_propuesta)
        {
            this._idpropuesta = id_propuesta;
        }


        /// <summary>
        /// Metodo para obtener el ID del gerente del proyecto
        /// </summary>
        /// <returns>Retorna el ID del gerente del proyecto</returns>
        public int getId_Gerente()
        {
            return this._idgerente;
        }


        /// <summary>
        /// Metodo para setear el ID del gerente del proyecto
        /// </summary>
        /// <param name="id_gerente"></param>
        public void setId_Gerente(int id_gerente)
        {
            this._idgerente = id_gerente;
        }

        /// <summary>
        /// Metodo para obtener el ID del responsable del proyecto
        /// </summary>
        /// <returns>Retorna el ID del responsable del proyecto</returns>
        public int getId_Responsable()
        {
            return this._idresponsable;
        }


        /// <summary>
        /// Metodo para setear el ID del responsable del proyecto
        /// </summary>
        /// <param name="id_responsable"></param>
        public void setId_Responsable(int id_responsable)
        {
            this._idresponsable = id_responsable;
        }



        #endregion
    }
}