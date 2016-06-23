using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M6
{
    public class Requerimiento : Entidad
    {
        #region Atributos

        /// <summary>
        /// Clase Requerimiento
        /// <attr name="_codigoRG">Codigo unico indentificador del requerimiento asociado a una propuesta</attr>
        /// <attr name="_descripcion">breve descripcion del requerimientos</attr>
        /// </summary>

        private string _codigoRequerimiento;
        private string _descripcion;
        private string _codigoPropuesta;
        private int p1;
        private string p2;
        private string p3;
        #endregion

        #region Propiedades

        /// <summary>
        /// Get del Codigo del Requerimiento
        /// </summary>
       
        public string CodigoRequerimiento
        {
            get { return _codigoRequerimiento; }

        }
        /// <summary>
        /// Get de la descripcion del Requerimiento
        /// </summary>
       
        public string Descripcion
        {
            get { return _descripcion; }

        }
        /// <summary>
        /// Get del Codigo de la propuesta en Requerimiento
        /// </summary>
       
        public string CodigoPropuesta
        {
            get { return _codigoPropuesta; }

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto del Requerimiento sin parametros
        /// </summary>
       
        public Requerimiento()
        {

        }
        /// <summary>
        /// Sobrecarga del constructor 
        /// </summary>
        /// <param name="codreq"></param>
        /// <param name="descripr"></param>
        /// <param name="codpro"></param>
       
        public Requerimiento(string codreq, string descripr, string codpro)
        {
            this._codigoRequerimiento = codreq;
            this._descripcion = descripr;
            this._codigoPropuesta = codpro;
        }

        #endregion

    }
}